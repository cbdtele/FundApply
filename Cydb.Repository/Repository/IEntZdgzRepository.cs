using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface IEntZdgzRepository {
        /// <summary>
        /// ��ȡ�ص��ע��ҵ�б�������ע���ʲ�����
        /// </summary>
        /// <returns></returns>
        int GetEntZdgzCount();

        /// <summary>
        /// ��ȡ�ص��ע��ҵ�б�ע���ʲ�����
        /// </summary>
        /// <returns></returns>
        List<object> GetEntZdgzList();

    }
}