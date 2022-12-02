using System;
using System.Collections.Generic;
using MySqlConnector;
using Domain;
using Data;
using System.Collections;
using System.Diagnostics;

namespace Business
{
    public class ProductBusiness
    {
        public List<Product> Show()
        {
            List<Product> list = new List<Product>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los productos 
                data.setQuery("Select * from Products"); //-> Despues cambiar esto por un StoredProcedure
                //string sp = ""; 
                //data.setProcedure(sp);
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Product aux = new Product();
                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.Name = data.Reader["Name"].ToString();
                    aux.Description = data.Reader["Description"].ToString();
                    aux.Price = Convert.ToDecimal(data.Reader["Price"]);
                    aux.Stock = Convert.ToInt16(data.Reader["Stock"]);
                    aux.Size = (int)data.Reader["Size"];
                    aux.Color = data.Reader["Color"].ToString();
                    aux.State = Convert.ToBoolean(data.Reader["State"]);
                    aux.ImageUrl = data.Reader["ImageUrl"].ToString();

                    //Se agrega el registro leído a la lista de productos
                    list.Add(aux);

                }

                //devuelvo listado de productos
                return list;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {   //se cierra la conexión a DB
                data.closeConnection();
            }
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los productos 
                data.setQuery("Select * from Products where Id = " + id + ";"); 
                //string sp = ""; 
                //data.setProcedure(sp);
                data.executeQuery();

                Product aux = new Product();
                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.Name = data.Reader["Name"].ToString();
                    aux.Description = data.Reader["Description"].ToString();
                    aux.Price = Convert.ToDecimal(data.Reader["Price"]);
                    aux.Stock = Convert.ToInt16(data.Reader["Stock"]);
                    aux.Size = (int)data.Reader["Size"];
                    aux.Color = data.Reader["Color"].ToString();
                    aux.State = Convert.ToBoolean(data.Reader["State"]);
                    aux.ImageUrl = data.Reader["ImageUrl"].ToString();
                }

                //devuelvo listado de productos
                return aux;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {   //se cierra la conexión a DB
                data.closeConnection();
            }
        }
        public void Add(Product newProduct)
        {
            //Se abre la conexión a DB
            AccessData datos = new AccessData();

            try
            {   //Se inserta en DB los datos cargados 
                datos.setQuery("Insert into Products (Name, Description, Price, Stock, Size, Color, State, ImageUrl) values (@Name, @Description, @Price, @Stock, @Size, @Color, @State, @ImaegenUrl);");
                datos.SetParameter("@Name", newProduct.Name);
                datos.SetParameter("@Description", newProduct.Description);
                datos.SetParameter("@Price", newProduct.Price);
                datos.SetParameter("@Stock", newProduct.Stock);
                datos.SetParameter("@Size", newProduct.Size);
                datos.SetParameter("@Color", newProduct.Color);
                datos.SetParameter("@State", newProduct.State);
                datos.SetParameter("@ImageUrl", newProduct.ImageUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se abre la conexión a DB
                datos.closeConnection();
            }
        }

        public void Modify(Product modProduct)
        {
            //Se abre la conexión a DB
            AccessData datos = new AccessData();

            try
            {   //Se inserta en DB los datos cargados en la plantilla "modificar"
                datos.setQuery("update Products set Name=@Name, Description=@Description, Price=@Price, Stock=@Stock, Size=@Size, Color=@Color, State=@State );");
                datos.SetParameter("@Id", modProduct.Id);
                datos.SetParameter("@Name", modProduct.Name);
                datos.SetParameter("@Description", modProduct.Description);
                datos.SetParameter("@Price", modProduct.Price);
                datos.SetParameter("@Stock", modProduct.Stock);
                datos.SetParameter("@Size", modProduct.Size);
                datos.SetParameter("@Color", modProduct.Color);
                datos.SetParameter("@State", modProduct.State);
                datos.SetParameter("@ImageUrl", modProduct.ImageUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se cierra la conexión a DB
                datos.closeConnection();
            }
        }

        public void Delete(int id) 
        {
            AccessData datos = new AccessData();
            try
            {   //Se elimina el registro
                datos.setQuery("Update from Products set State = 0 where Id=@Id");
                datos.SetParameter("@Id", id);
                datos.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se abre la conexión a DB
                datos.closeConnection();
            }
        }

        public List<Product> Filter(string searchBy, string when, string filter)
        {
            List<Product> list = new List<Product>();
            AccessData data = new AccessData();

            string query = "";

            try
            {
                //A CHEQUEAR...
                if (searchBy == "Precio")
                {
                    switch (when)
                    {
                        case "Mayor a":
                            query += "P.Precio > " + filter;
                            break;
                        case "Menor a":
                            query += "P.Precio < " + filter;
                            break;
                        case "Igual a":
                            query += "P.Precio = " + filter;
                            break;
                    }
                }
                else
                {
                    string column = "";
                    switch (searchBy)
                    {
                        case "Código":
                            column = "P.Id";
                            break;
                        case "Nombre":
                            column = "P.Name";
                            break;
                        case "Color":
                            column = "P.Color";
                            break;
                    }
                    switch (searchBy)
                    {
                        case "Igual a":
                            query += column + " like '" + filter + "'";
                            break;
                        case "Contiene":
                            query += column + " like '%" + filter + "%'";
                            break;
                        case "Comienza con":
                            query += column + " like '" + filter + "%'";
                            break;
                        case "Termina con":
                            query += column + " like '%" + filter + "'";
                            break;
                    }
                }

                data.setQuery(query);
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan los articulos de la base
                    Product aux = new Product();
                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.Name = data.Reader["Name"].ToString();
                    aux.Description = data.Reader["Description"].ToString();
                    aux.Price = Convert.ToDecimal(data.Reader["Price"]);
                    aux.Stock = Convert.ToInt16(data.Reader["Stock"]);
                    aux.Size = (int)data.Reader["Size"];
                    aux.Color = data.Reader["Color"].ToString();
                    aux.State = Convert.ToBoolean(data.Reader["State"]);

                    //Se agrega el registro leído a la lista de articulos
                    list.Add(aux);

                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //se cierra la conexión a DB
                data.closeConnection();
            }
        }
    }
}

