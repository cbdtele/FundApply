using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface IEntZczbChangeRepository {
        /// <summary>
        /// ��ȡ��ҵ�䶯״���б�ע���ʲ�����
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<object> GetEntZczjList(EntZczbChangeRepository.EntZczbChangeDto dto);
        /// <summary>
        /// ��ȡ��ҵ�䶯״���б�������ע���ʲ�����
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int GetEntZczjCount(EntZczbChangeRepository.EntZczbChangeDto dto);
    }
}