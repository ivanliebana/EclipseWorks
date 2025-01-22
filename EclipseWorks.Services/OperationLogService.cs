using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Exceptions;
using EclipseWorks.Services.Interfaces;
using System.Transactions;

namespace EclipseWorks.Services
{
    public class OperationLogService(IUnitOfWork unitOfWork) : IOperationLogService
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OperationLogModel> AddAsync(OperationLogModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            await _unitOfWork.OperationLog.AddAsync(entity, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            scope.Complete();

            return entity;
        }

        public async Task<bool> DeleteAsync(OperationLogModel entity, CancellationToken ct)
        {
            CustomException.When(entity.Id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.OperationLog.FindOneAsync(x => x.Id == entity.Id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("OperationLog", "Id"));

            _unitOfWork.OperationLog.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(long id, CancellationToken ct)
        {
            CustomException.When(id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.OperationLog.FindOneAsync(x => x.Id == id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("OperationLog", "Id"));

            _unitOfWork.OperationLog.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<IEnumerable<OperationLogModel>> GetAllAsync(CancellationToken ct)
        {
            var list = await _unitOfWork.OperationLog.FindListAsync(x => x.Id > 0, ct);
            return list;
        }

        public async Task<OperationLogModel> GetByIdAsync(long id, CancellationToken ct)
        {
            if (id > 0)
            {
                var OperationLog = await _unitOfWork.OperationLog.FindOneAsync(x => x.Id == id, ct);

                if (OperationLog != null)
                    return OperationLog;
            }

            return null;
        }

        public async Task<OperationLogModel> UpdateAsync(OperationLogModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            var obj = await _unitOfWork.OperationLog.FindOneAsync(x => x.Id == entity.Id, ct, new Core.FindOptions { IsAsNoTracking = true });
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("OperationLog", "Id"));

            _unitOfWork.OperationLog.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return obj;
        }

        private async Task Validation(OperationLogModel entity, CancellationToken ct)
        {
            CustomException.When(entity == null, "Informação de 'OperationLog' não preenchida corretamente.");
        }
    }
}