using APIServicePractice002.DTO.Entities;
using System;

namespace APIServicePractice002.BSL.BSLUtility
{
    public static class ResultHandle
    {
        public static void ExceptionHandle(Exception ex,ResultEntity resultEntity, Enums.Error error)
        {
            var num = (int)error;
            resultEntity.errorCode = num.ToString().PadLeft(4,'0');
            resultEntity.errorMessage = error.ToString();
            resultEntity.statusMessage = Enums.Status.Unsuccess.ToString();
        }
        public static void SuccessHandle(ResultEntity resultEntity)
        {
            var num = (int)Enums.Error.None;
            resultEntity.errorCode = num.ToString().PadLeft(4, '0');
            resultEntity.statusMessage = Enums.Status.Success.ToString();
        }
    }
}
