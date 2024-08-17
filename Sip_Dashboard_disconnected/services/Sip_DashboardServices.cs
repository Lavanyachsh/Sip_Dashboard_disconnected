using Sip_Dashboard_disconnected.Dtos;
using Sip_Dashboard_disconnected.Entities;
using Sip_Dashboard_disconnected.Interfcaes;

namespace Sip_Dashboard_disconnected.services
{
    public class Sip_DashboardServices : ISipDashboardServices
    {
      public readonly  ISipDashboardRepositiories _sipdashboardRepositories;
        public Sip_DashboardServices(ISipDashboardRepositiories sipdashboardRepositories)

        { 
            _sipdashboardRepositories = sipdashboardRepositories;
        }
        public async Task<bool> AddSip_dashboard(Sip_DashboardDtos sip_dashboarddetail)
        {
           Sip_Dashboard obj = new Sip_Dashboard();
            obj.name = sip_dashboarddetail.name;
            obj.weight = sip_dashboarddetail.weight;
            obj.symbol = sip_dashboarddetail.symbol;
            obj.location = sip_dashboarddetail.location;
            
            await _sipdashboardRepositories.AddSip_dashboard(obj);
            return true;
        }

        public async Task<bool> DeleteSip_dashboard(int position)
        {
            await _sipdashboardRepositories.DeleteSip_dashboard(position);
            return true;
           
        }

        public async Task<List<Sip_DashboardDtos>> GetSip_dashboard()
        {
            List<Sip_DashboardDtos> lstsip=new List<Sip_DashboardDtos>();
            var result = await _sipdashboardRepositories.GetSip_dashboard();
            foreach (Sip_Dashboard sip in result)
            {
                Sip_DashboardDtos sipdto = new Sip_DashboardDtos();
                sipdto.position = sip.position;
                sipdto.weight = sip.weight;
                sipdto.symbol = sip.symbol;
                sipdto.name = sip.name;
                sipdto.location = sip.location;
                lstsip.Add(sipdto);
            }
            return lstsip;
        }

        public async Task<Sip_DashboardDtos> GetSip_dashboardByPosition(int position)
        {
            var result = await _sipdashboardRepositories.GetSip_dashboardByPosition(position);
            
                Sip_DashboardDtos sipdto = new Sip_DashboardDtos();
                sipdto.position = result.position;
                sipdto.weight = result.weight;
                sipdto.symbol = result.symbol;
                sipdto.name = result.name;
                sipdto.location = result.location;
            
            return sipdto;
        }

        public async Task<bool> UpdateSip_dashboard(Sip_DashboardDtos sip_dashboarddetail)
        {
            Sip_Dashboard sipobj= new Sip_Dashboard();
            sipobj.position = sip_dashboarddetail.position;
            sipobj.weight = sip_dashboarddetail.weight;
            sipobj.symbol = sip_dashboarddetail.symbol;
            sipobj.name = sip_dashboarddetail.name;
            sipobj.location = sip_dashboarddetail.location;

            await _sipdashboardRepositories.UpdateSip_dashboard(sipobj);
            return true;
        }
        
    }
}
