using Sip_Dashboard_disconnected.Dtos;
using Sip_Dashboard_disconnected.Entities;

namespace Sip_Dashboard_disconnected.Interfcaes
{
    public interface ISipDashboardServices
    {
        Task<List<Sip_DashboardDtos>> GetSip_dashboard();
        Task<Sip_DashboardDtos> GetSip_dashboardByPosition(int position);
        Task<bool> AddSip_dashboard(Sip_DashboardDtos sip_dashboarddetail);
        Task<bool> UpdateSip_dashboard(Sip_DashboardDtos sip_dashboarddetail);
        Task<bool> DeleteSip_dashboard(int position);
    }
}
