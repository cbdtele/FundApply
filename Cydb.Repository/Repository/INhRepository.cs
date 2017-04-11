using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface INhRepository {
        /// <summary>
        /// ��ȡͳ����ҵ����
        /// </summary>
        /// <returns></returns>
        int GetStatisticsEntNums();

        /// <summary>
        /// ����ʱ���ȡ�����ȵ�ֵ��ͬ��
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        dynamic GetValueAndTbByTime(string time);

        /// <summary>
        /// ��ȡ˰�պ��ܺ�����ͼ
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetTaxAndNhListChart(string time);

        /// <summary>
        /// ��ȡGDP���ܺ�����ͼ
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetGdpAndNhListChart(string time);

        /// <summary>
        /// ��ȡ�ܺ��зֲ��е�һ����ҵ�����б�
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetNhHyfbList(string time);

        /// <summary>
        /// �ܺ���ҵ�ֲ� �� ʱ��Բ��ͼ
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetNhHyChar(string time);

        /// <summary>
        /// �ھ�˵�� ������� ��
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetAllByYear(string beginTime);

        /// <summary>
        /// �ھ�˵�� ������� ��
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetMonthByYear(string year);

        List<dynamic> Get123CList(string time, bool issearchflag = true, string pIndustryId = "0");
        List<dynamic> GetNhZdcyList(string time);
        List<dynamic> GetNhZdcyChart(string time);
        List<dynamic> GetNhXtlbList(string time);
        List<dynamic> GetNhQylxList(string time);
        List<dynamic> GetNhQylxChart(string time);
        List<dynamic> GetNhGnqListAndChart(string beginTime, string endTime);
    }
}