using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Exceptions;
using EclipseWorks.Services.Interfaces;
using System.Transactions;

namespace EclipseWorks.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<UserModel> AddAsync(UserModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            await _unitOfWork.User.AddAsync(entity, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            scope.Complete();

            return entity;
        }

        public async Task<bool> DeleteAsync(UserModel entity, CancellationToken ct)
        {
            CustomException.When(entity.Id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.User.FindOneAsync((System.Linq.Expressions.Expression<Func<UserModel, bool>>)(x => x.Id == entity.Id), ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Users", "Id"));

            _unitOfWork.User.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(long id, CancellationToken ct)
        {
            CustomException.When(id <= 0, Message.MSG0016("Id"));

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var obj = await _unitOfWork.User.FindOneAsync(x => x.Id == id, ct);
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Users", "Id"));

            _unitOfWork.User.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return true;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken ct)
        {
            var list = await _unitOfWork.User.FindListAsync(x => x.Id > 0, ct);
            return list;
        }

        public async Task<UserModel> GetByIdAsync(long id, CancellationToken ct)
        {
            if (id > 0)
            {
                var obj = await _unitOfWork.User.FindOneAsync(x => x.Id == id, ct);

                if (obj != null)
                    return obj;
            }

            return null;
        }

        public async Task<UserModel> UpdateAsync(UserModel entity, CancellationToken ct)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            await Validation(entity, ct);

            var obj = await _unitOfWork.User.FindOneAsync((System.Linq.Expressions.Expression<Func<UserModel, bool>>)(x => x.Id == entity.Id), ct, new Core.FindOptions { IsAsNoTracking = true });
            CustomException.When(obj == null || obj.Id <= 0, Message.MSG0049("Users", "Id"));

            _unitOfWork.User.Update(obj);

            await _unitOfWork.SaveChangesAsync(ct);

            scope.Complete();

            return obj;
        }

        private async Task Validation(UserModel entity, CancellationToken ct)
        {
            CustomException.When(entity == null, "Informação de 'Users' não preenchida corretamente.");
        }
    }
}
