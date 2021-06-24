using CmsBlogWeb.Business.Configuration;
using CmsBlogWeb.Business.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CmsBlogWeb.Business.Services
{
    public class CmsBlogDbAccessService : ICmsBlogDbAccessService
    {
        private readonly AppSettings _appSettings;

        public CmsBlogDbAccessService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<int> ExecuteNonQuery(string commandText, Dictionary<string, string> parameters)
        {
            int result = 0;

            using (var connection = new SqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(commandText, connection, transaction))
                    {
                        if (parameters.Count > 0)
                        {
                            foreach(var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        result = await command.ExecuteNonQueryAsync();

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    throw;
                }
            }

            return result;
        }
    }
}
