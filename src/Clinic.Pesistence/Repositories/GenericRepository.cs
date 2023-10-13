using Clinic.Application.Interface.Interfaces;
using Clinic.Pesistence.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Pesistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        public GenericRepository( ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objectParam = new DynamicParameters(parameter);
            return await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, param: objectParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> ExecAsync(string storedProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objectParam = new DynamicParameters(parameters);
            var recordAffected = await connection.ExecuteAsync(storedProcedure, param: objectParam, commandType: CommandType.StoredProcedure);
            return recordAffected > 0;
        }

    }
}
