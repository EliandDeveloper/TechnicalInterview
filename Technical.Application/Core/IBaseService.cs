

namespace Technical.Application.Core
{
    public interface IBaseService <TDtoAdd, TDtoUpdate, TDtoRemove, TKey>
    {
        ServiceResult GetAll();
        ServiceResult GetById(TKey Id);
        ServiceResult Save(TDtoAdd dtoAdd);
        ServiceResult Update(TDtoUpdate dtoUpdate);
        ServiceResult Remove(TDtoRemove dtoRemove);
    }
}
