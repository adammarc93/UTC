using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UTCService
{
    public class CarService : ICarService
    {
        private SqlConnection con;

        public CarService()
        {
            con = new SqlConnection("Data Source=DESKTOP-BSBRCG2\\LENOVOG50;Initial Catalog=UTC;User ID=sa;Password=FokaKura12!;");
        }

        public List<Car> GetCars()
        {
            var ds = new DataSet();
            var result = new List<Car>();

            try
            {
                string Query = "SELECT * FROM [UTC].[dbo].Cars";

                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.Fill(ds);

                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    result.Add(new Car
                    {
                        Id = Convert.ToInt32(record["Id"]),
                        Brand = Convert.ToString(record["Brand"]),
                        Model = Convert.ToString(record["Model"]),
                        TotalCost = Convert.ToInt32(record["TotalCost"]),
                        YearOfProduction = Convert.ToInt32(record["YearOfProduction"]),
                        Mileage = Convert.ToInt32(record["Mileage"]),
                        Fuel = Convert.ToString(record["Fuel"]),
                        CarType = Convert.ToString(record["CarType"]),
                        Seats = Convert.ToInt32(record["Seats"]),
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

        public void PostCar(Car newCar)
        {
            try
            {
                string Query = @"INSERT INTO [UTC].[dbo].Cars (Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, CarType, Seats, Color, CarStatus)
	                             VALUES (@Brand, @Model, @TotalCost, @YearOfProduction, @Mileage, @Fuel, @CarType, @Seats, @Color, @CarStatus)";
                var cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Brand", newCar.Brand);
                cmd.Parameters.AddWithValue("@Model", newCar.Model);
                cmd.Parameters.AddWithValue("@TotalCost", newCar.TotalCost);
                cmd.Parameters.AddWithValue("@YearOfProduction", newCar.YearOfProduction);
                cmd.Parameters.AddWithValue("@Mileage", newCar.Mileage);
                cmd.Parameters.AddWithValue("@Fuel", newCar.Fuel);
                cmd.Parameters.AddWithValue("@CarType", newCar.CarType);
                cmd.Parameters.AddWithValue("@Seats", newCar.Seats);
                cmd.Parameters.AddWithValue("@Color", newCar.Color);
                cmd.Parameters.AddWithValue("@CarStatus", newCar.CarStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (FaultException ex)
            {
                throw new FaultException<string>("Error: " + ex);
            }
        }

        public void PutCar(Car newCar)
        {
            try
            {
                string Query = "UPDATE [UTC].[dbo].Cars "
                                + "SET Brand=@Brand, Model=@Model, TotalCost=@TotalCost, YearOfProduction=@YearOfProduction, "
                                + "Mileage=@Mileage, Fuel=@Fuel, CarType=@CarType, Color=@Color, CarStatus=@CarStatus "
                                + "WHERE Id=@Id";
                var cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Id", newCar.Id);
                cmd.Parameters.AddWithValue("@Brand", newCar.Brand);
                cmd.Parameters.AddWithValue("@Model", newCar.Model);
                cmd.Parameters.AddWithValue("@TotalCost", newCar.TotalCost);
                cmd.Parameters.AddWithValue("@YearOfProduction", newCar.YearOfProduction);
                cmd.Parameters.AddWithValue("@Mileage", newCar.Mileage);
                cmd.Parameters.AddWithValue("@Fuel", newCar.Fuel);
                cmd.Parameters.AddWithValue("@CarType", newCar.CarType);
                cmd.Parameters.AddWithValue("@Seats", newCar.Seats);
                cmd.Parameters.AddWithValue("@Color", newCar.Color);
                cmd.Parameters.AddWithValue("@CarStatus", newCar.CarStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>("Error: " + ex);
            }
        }

        public void DeleteCar(int id)
        {
            try
            {
                string Query = "DELETE FROM [UTC].[dbo].Cars WHERE Id=@Id";
                var cmd = new SqlCommand(Query, con);

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
    }
}
