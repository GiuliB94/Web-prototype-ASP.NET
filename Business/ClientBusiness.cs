﻿using System;
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
                data.setQuery("Select * from Clients where State = true");
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
                    aux.adress = data.Reader["Address"].ToString();
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
                data.setQuery("Select * from Clients where State = false");
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
                    aux.adress = data.Reader["Address"].ToString();
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
                data.setQuery("Insert into Clients (Name, LastName, Phone, Province, City, PostalCode, IdUser, Adress, DNI, State) values " + "('" + newClient.Name + "','" + newClient.LastName + "','" + newClient.Phone + "','" + newClient.Province + "','" + newClient.City + "','" + newClient.PostalCode + "'," + newClient.IdUser + ",'" + newClient.Adress + "','" + newClient.DNI + "'," + newClient.State + " );");
                data.executeQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se abre la conexión a DB
                data.closeConnection();
            }
        }

        public void Modify(Client modClient)
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {   //Se inserta en DB los data cargados en la plantilla "modificar"
                data.setQuery("");
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
            AccessData data = new AccessData();
            try
            {   //Se elimina el registro
                data.setQuery("delete from Clients where Id=@Id");
                data.SetParameter("@Id", id);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se abre la conexión a DB
                data.closeConnection();
            }
        }

        public List<Client> Filter(string searchBy, string state="3", string filter="")
        {
            List<Client> list = new List<Client>();
            AccessData data = new AccessData();

            string query = "Select * from Clients where ";

            try
            {
                //A CHEQUEAR...
                //if (searchBy == "Category")
                //{
                //    switch (when)
                //    {
                //        case "Mayor a":
                //            query += "C.Category > " + filter;
                //            break;
                //        case "Menor a":
                //            query += "C.Category < " + filter;
                //            break;
                //        case "Igual a":
                //            query += "C.Category = " + filter;
                //            break;
                //    }
                //}

                string column="";
                switch (searchBy)
                {
                    case "Nombre":
                        column = "Name like '%" + filter + "%'";
                        break;
                    case "Apellido":
                        column = "LastName like '%" + filter + "%'";
                        break;
                    case "DNI":
                        column = "DNI like '" + filter + "'";
                        break;
                }
                query+=column;


                //switch (searchBy)
                //{
                //    case "Igual a":
                //        query += column + " like '" + filter + "'";
                //        break;
                //    case "Contiene":
                //        query += column + " like '%" + filter + "%'";
                //        break;
                //    case "Comienza con":
                //        query += column + " like '" + filter + "%'";
                //        break;
                //    case "Termina con":
                //        query += column + " like '%" + filter + "'";
                //        break;
                //}

                if (state == "Activo")
                {
                    query += " and State= 1";
                }

                else if (state == "Inactivo")
                {
                    query += " and State= 0";
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
                    aux.adress = data.Reader["Address"].ToString();
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

