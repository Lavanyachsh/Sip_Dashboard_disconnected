using Sip_Dashboard_disconnected.Entities;

namespace Sip_Dashboard_disconnected.Interfcaes
{
    public interface ISipDashboardRepositiories
    {
        Task<List<Sip_Dashboard>> GetSip_dashboard();
        Task <Sip_Dashboard> GetSip_dashboardByPosition(int  position);
        Task <bool> AddSip_dashboard(Sip_Dashboard sip_dashboarddetail);
        Task <bool> UpdateSip_dashboard(Sip_Dashboard sip_dashboarddetail);
        Task<bool> DeleteSip_dashboard(int position);

    }
}
