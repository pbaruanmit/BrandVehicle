using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShowroomSelfhost
{
    public class ShowroomController : ApiController
    {
        public List<string> GetBrandNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT brand_name FROM Brand", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows) lcNames.Add((string)dr[0]); return lcNames;
        }
        public clsBrand GetArtist(string Name)

        {

            Dictionary<string, object> par = new Dictionary<string, object>(1);

            par.Add("Name", Name);

            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Brand WHERE brand_name = @Name", par);

            if (lcResult.Rows.Count > 0)

                return new clsBrand()

                {
                    BrandName = (string)lcResult.Rows[0]["brand_name"],
                    BrandDescription = (string)lcResult.Rows[0]["brand_description"],
                    //Phone = (string)lcResult.Rows[0]["Phone"]
                    VehicleList = getBrandVehicles(Name)
                };
            else
                return null;

        }
        public clsVehicle GetVehicle(string Name)

        {

            Dictionary<string, object> par = new Dictionary<string, object>(1);

            par.Add("Name", Name);

            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Vehicle WHERE VehicleRegistrationNo = @Name", par);

            if (lcResult.Rows.Count > 0)

                return new clsVehicle()

                {
                    VehicleType = (string)lcResult.Rows[0]["VehicleType"],
                    VehicleModel = (string)lcResult.Rows[0]["VehicleModel"],
                    VehiclePrice = Convert.ToString(lcResult.Rows[0]["VehiclePrice"]),
                    VehicleRegNo = (string)lcResult.Rows[0]["VehicleRegistrationNo"],
                };
            else
                return null;

        }
        private List<clsVehicle> getBrandVehicles(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Vehicle WHERE BrandName = @Name", par);
            List<clsVehicle> lcWorks = new List<clsVehicle>();
            foreach (DataRow dr in lcResult.Rows)
                lcWorks.Add(dataRow2AllVehicles(dr));
            return lcWorks;
        }

        private clsVehicle dataRow2AllVehicles(DataRow prDataRow)
        {
            return new clsVehicle()
            {
                VehicleModel = Convert.ToString(prDataRow["VehicleModel"]),
                VehicleType = Convert.ToString(prDataRow["VehicleType"]),
                VehiclePrice = Convert.ToString(prDataRow["VehiclePrice"]),
                VehicleRegNo = Convert.ToString(prDataRow["VehicleRegistrationNo"]),
            };
        }

        public string PutArtist(clsBrand prArtist)

        { // update

            try

            {
                int lcRecCount = clsDbConnection.Execute(
                "UPDATE Brand SET brand_description = @brandDescription WHERE brand_name = @brandName",
                prepareArtistParameters(prArtist));
                if (lcRecCount == 1)

                    return "One brand updated";

                else

                    return "Unexpected brand update count: " + lcRecCount;

            }

            catch (Exception ex)

            {
                return ex.GetBaseException().Message;
            }

        }

        private Dictionary<string, object> prepareArtistParameters(clsBrand prArtist)

        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("brandName", prArtist.BrandName);
            par.Add("brandDescription", prArtist.BrandDescription);
            //par.Add("Phone", prArtist.Phone);
            return par;

        }
    }
}
