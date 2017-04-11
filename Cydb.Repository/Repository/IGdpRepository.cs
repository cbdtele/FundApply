using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface IGdpRepository {
        List<dynamic> GetAllList();
        dynamic GetSingelByTime(string time);
        List<dynamic> GetDgpHyfbList(string beginTime, string pIndustryId);
        List<dynamic> GetGdpContinuousUp(string time, string targetColumn, string upOrDown);
        List<dynamic> GetGdpHyChar(string time);
        List<dynamic> Get123CList(string time);
        List<dynamic> GetGdpDzcyList(string time);
        List<dynamic> GetGdpXtlbList(string time);
        List<dynamic> GetGdpQylxList(string time);
        List<dynamic> GetGdpQylxChart(string time);
        List<dynamic> GetGdpGnqList(string time);
    }
}