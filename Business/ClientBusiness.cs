using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
using Domain;
using Data;
using System.IO;

namespace Business
{
    public class ClientBusiness
    {
        public List<Client> Show()
        {
            List<Client> list = new List<Client>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los clients //JOIN CON COMPANIES...
                data.setQuery("Select * from Clients where state = true");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Client aux = new Client();
                    aux.id = Convert.ToInt16(data.Reader["Id"]);
                    aux.idUser = Convert.ToInt16(data.Reader["IdUser"]);
                    aux.name = data.Reader["Name"].ToString();
                    aux.lastName = data.Reader["LastName"].ToString();
                    aux.phone = data.Reader["Phone"].ToString();
                    aux.address = data.Reader["Adress"].ToString();
                    aux.city = data.Reader["City"].ToString();
                    aux.postalCode = data.Reader["PostalCode"].ToString();
                    aux.province = data.Reader["Province"].ToString();
                    aux.dni = data.Reader["DNI"].ToString();
                    aux.state = Convert.ToBoolean(data.Reader["State"]);

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

        public List<Client> ShowPendings()
        {
            List<Client> list = new List<Client>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los clients //JOIN CON COMPANIES...
                data.setQuery("Select * from Clients where state = false");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Client aux = new Client();
                    aux.id = Convert.ToInt16(data.Reader["Id"]);
                    aux.idUser = Convert.ToInt16(data.Reader["IdUser"]);
                    aux.name = data.Reader["Name"].ToString();
                    aux.lastName = data.Reader["LastName"].ToString();
                    aux.phone = data.Reader["Phone"].ToString();
                    aux.address = data.Reader["Adress"].ToString();
                    aux.city = data.Reader["City"].ToString();
                    aux.postalCode = data.Reader["PostalCode"].ToString();
                    aux.province = data.Reader["Province"].ToString();
                    aux.state = Convert.ToBoolean(data.Reader["State"]);

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

        public void Add(Client newClient)
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {   //Se inserta en DB los data cargados 
                data.setQuery($"Insert Into Clients(Name, LastName, Phone, Province, City, PostalCode, Address, DNI) Values ('{newClient.name}', '{newClient.lastName}', '{newClient.phone}', '{newClient.province}', '{newClient.city}', '{newClient.postalCode}', '{newClient.address}', '{newClient.dni}')");
                //TODO: setear parámetros? - Lucas
                data.executeQuery();
            }
            catch (Exception ex)
            {
                throw ex; //TODO: Manejar excepción cuando se añade un cliente nuevo - Lucas
            }
            finally
            {   //Se cierra la conexión a DB
                data.closeConnection();
            }
        }

        public void Modify(Client modClient)
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {   //Se inserta en DB los data cargados en la plantilla "modificar"
                data.setQuery("Clients SET Name = @Name, LastName = @LastName, Phone = @Phone, Province = @Province, City = @City, PostalCode = @PostalCode, State = @State, IdUser = @IdUser, Address = @Address, DNI = @DNI WHERE Id = @Id");
                data.SetParameter("@Name", modClient.name);
                data.SetParameter("@LastName", modClient.lastName);
                data.SetParameter("@Phone", modClient.phone);
                data.SetParameter("@Province", modClient.province);
                data.SetParameter("@City", modClient.city);
                data.SetParameter("@PostalCode", modClient.postalCode);
                data.SetParameter("@State", modClient.state);
                data.SetParameter("@IdUser", modClient.idUser);
                data.SetParameter("@Address", modClient.address);
                data.SetParameter("@DNI", modClient.dni);
                data.SetParameter("@Id", modClient.id);
                data.executeQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se cierra la conexión a DB
                data.closeConnection();
            }
        }

        public void Delete(int id)
        {
            AccessData datos = new AccessData();
            try
            {   //Se elimina el registro
                datos.setQuery("delete from Clients where Id=@id");
                datos.SetParameter("@id", id);
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

        public List<Client> Filter(string searchBy, string when, string filter)
        {
            List<Client> list = new List<Client>();
            AccessData data = new AccessData();

            string query = "";

            try
            {
                //A CHEQUEAR...
                if (searchBy == "Category")
                {
                    switch (when)
                    {
                        case "Mayor a":
                            query += "C.Category > " + filter;
                            break;
                        case "Menor a":
                            query += "C.Category < " + filter;
                            break;
                        case "Igual a":
                            query += "C.Category = " + filter;
                            break;
                    }
                }
                else
                {
                    string column;
                    switch (searchBy)
                    {
                        case "Name":
                            column = "C.Name";
                            break;
                        case "Last Name":
                            column = "C.LastName";
                            break;
                        case "Email":
                            column = "C.Email";
                            break;
                        case "Phone":
                            column = "C.Phone";
                            break;
                        default:
                            column = "ACAIRIAELCOMPANYNAME?";
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
                    Client aux = new Client();
                    aux.id = Convert.ToInt16(data.Reader["Id"]);
                    aux.idUser = Convert.ToInt16(data.Reader["IdUser"]);
                    aux.name = data.Reader["Name"].ToString();
                    aux.lastName = data.Reader["LastName"].ToString();
                    aux.phone = data.Reader["Phone"].ToString();
                    aux.address = data.Reader["Adress"].ToString();
                    aux.city = data.Reader["City"].ToString();
                    aux.postalCode = data.Reader["PostalCode"].ToString();
                    aux.province = data.Reader["Province"].ToString();
                    aux.dni = data.Reader["DNI"].ToString();
                    aux.state = Convert.ToBoolean(data.Reader["State"]);

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

