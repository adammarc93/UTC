using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace UTCService
{
    public class TruckService : ITruckService
    {
        private SqlConnection con;

        public TruckService()
        {
            con = new SqlConnection("Data Source=DESKTOP-BSBRCG2\\LENOVOG50;Initial Catalog=UTC;User ID=sa;Password=FokaKura12!;");
        }

        public void AddTruck(Truck newTruck)
        {
            try
            {
                var cmd = new SqlCommand("crud_TruckInsert", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Brand", newTruck.Brand);
                cmd.Parameters.AddWithValue("@Model", newTruck.Model);
                cmd.Parameters.AddWithValue("@TotalCost", newTruck.TotalCost);
                cmd.Parameters.AddWithValue("@YearOfProduction", newTruck.YearOfProduction);
                cmd.Parameters.AddWithValue("@Mileage", newTruck.Mileage);
                cmd.Parameters.AddWithValue("@Fuel", newTruck.Fuel);
                cmd.Parameters.AddWithValue("@Color", newTruck.Color);
                cmd.Parameters.AddWithValue("@CarStatus", newTruck.CarStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (FaultException ex)
            {
                throw new FaultException<string>("Error: " + ex);
            }
        }

        public void DeleteTruck(int id)
        {
            try
            {
                var cmd = new SqlCommand("crud_TruckDelete", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>("Error: " + ex);
            }
        }

        public List<Truck> GetTrucks()
        {
            var ds = new DataSet();
            var result = new List<Truck>();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.crud_TruckReadAll", con);
                sda.Fill(ds);

                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    result.Add(new Truck
                    {
                        Id = Convert.ToInt32(record["Id"]),
                        Brand = Convert.ToString(record["Brand"]),
                        Model = Convert.ToString(record["Model"]),
                        TotalCost = Convert.ToInt32(record["TotalCost"]),
                        YearOfProduction = Convert.ToInt32(record["YearOfProduction"]),
                        Mileage = Convert.ToInt32(record["Mileage"]),
                        Fuel = Convert.ToString(record["Fuel"]),
                        Color = Convert.ToString(record["Color"]),
                        CarStatus = Convert.ToString(record["CarStatus"])
                    });
                }
            }
            catch (FaultException ex)
            {
                throw new FaultException<string>("Error: " + ex);
            }

            return result;
        }

        public void UpdateTruck(Truck newTruck)
        {
            try
            {
                var cmd = new SqlCommand("crud_TruckUpdate", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", newTruck.Id);
                cmd.Parameters.AddWithValue("@Brand", newTruck.Brand);
                cmd.Parameters.AddWithValue("@Model", newTruck.Model);
                cmd.Parameters.AddWithValue("@TotalCost", newTruck.TotalCost);
                cmd.Parameters.AddWithValue("@YearOfProduction", newTruck.YearOfProduction);
                cmd.Parameters.AddWithValue("@Mileage", newTruck.Mileage);
                cmd.Parameters.AddWithValue("@Fuel", newTruck.Fuel);
                cmd.Parameters.AddWithValue("@Color", newTruck.Color);
                cmd.Parameters.AddWithValue("@CarStatus", newTruck.CarStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>("Error: " + ex);
            }
        }
    }
}
