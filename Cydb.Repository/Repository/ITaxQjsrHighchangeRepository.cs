using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface ITaxQjsrHighchangeRepository {
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="targetColumn">Ŀ��ֵ</param>
        /// <param name="upordown">up ���� down</param>
        /// <returns></returns>
        List<object> GetTaxQjsrHighchange(string beginTime, string endTime, string targetColumn, string upordown);
    }
}