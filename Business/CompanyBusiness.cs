using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Net;

namespace Business
{
    public class CompanyBusiness
    {
        public List<Company> Show(int i=0)
        {
            List<Company> list = new List<Company>();
            AccessData data = new AccessData();

            //Se setea la query para traer los Companys //JOIN CON COMPANIES..., dependiendo si es listar usuarios y checkeos para altas trae solo los activos o activos/inactivos

            if (i == 0) {
                data.setQuery("Select * from Companies where IsActive = 1");
            }
            else
            {
                data.setQuery("Select * from Companies");
            }
            try
            {
                //Se setea la query para traer los Companys //JOIN CON COMPANIES...
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Company aux = new Company();
                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.IdUser = Convert.ToInt16(data.Reader["IdUser"]);
                    aux.Name = data.Reader["Name"].ToString();
                    aux.Phone = data.Reader["Phone"].ToString();
                    aux.Address = data.Reader["Address"].ToString();
                    aux.AddressExtra = data.Reader["AddressExtra"].ToString();
                    aux.City = data.Reader["City"].ToString();
                    aux.PostalCode = data.Reader["PostalCode"].ToString();
                    aux.Province = data.Reader["Province"].ToString();
                    aux.CUIT = data.Reader["CUIT"].ToString();
                    aux.IsActive = Convert.ToBoolean(data.Reader["IsActive"]);

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

        public List<Company> ShowPendings() //TODO: Debería haber un cruce con los states de User?
        {
            List<Company> list = new List<Company>();
            AccessData data = new AccessData();
            User user = new User();
            UserBusiness userBusiness = new UserBusiness();

            try
            {
                //Se setea la query para traer los Companys //JOIN CON COMPANIES...
                data.setQuery("Select * from Companies where IsActive = 0");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Company aux = new Company();
                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.IdUser = Convert.ToInt16(data.Reader["IdUser"]);
                    aux.Name = data.Reader["Name"].ToString();
                    aux.Phone = data.Reader["Phone"].ToString();
                    aux.Address = data.Reader["Address"].ToString();
                    aux.AddressExtra = data.Reader["AddressExtra"].ToString();
                    aux.City = data.Reader["City"].ToString();
                    aux.PostalCode = data.Reader["PostalCode"].ToString();
                    aux.Province = data.Reader["Province"].ToString();
                    aux.IsActive = Convert.ToBoolean(data.Reader["IsActive"]);
                    aux.CUIT = data.Reader["CUIT"].ToString();

                    //Se agrega el registro leído a la lista de productos(solo de aquellos aún no rechazados)
                    user = userBusiness.GetUser(aux.IdUser);
                    if (user.IsActive)
                    {
                        list.Add(aux);
                    }
                    

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

        public void Add(Company newCompany)
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {   //Se inserta en DB los data cargados 
                data.setQuery("Insert into Companies (Name, Phone, Province, City, PostalCode, IdUser, Address, AddressExtra, CUIT, IsActive) values " + "('" + newCompany.Name + "','" + newCompany.Phone + "','" + newCompany.Province + "','" + newCompany.City + "','" + newCompany.PostalCode + "'," + newCompany.IdUser + ",'" + newCompany.Address + "','" + newCompany.AddressExtra + "','" + newCompany.CUIT + "'," + newCompany.IsActive + " );");
                data.executeQuery();
            }
            catch (Exception ex)
            {
                throw ex; //TODO: Manejar excepción cuando se añade una compañia nueva - Lucas
            }
            finally
            {   //Se cierra la conexión a DB
                data.closeConnection();
            }
        }

        public void Modify(Company modCompany) //TODO: debería estar el IDUser como opción para modificar??
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {   //Se inserta en DB los data cargados en la plantilla "modificar"
                data.setQuery("Update Companies SET Name = @Name, Phone = @Phone, Province = @Province, City = @City, PostalCode = @PostalCode, IsActive = @State, IdUser = @IdUser, Address = @Address, AddressExtra = @AddressExtra, CUIT = @CUIT WHERE ID = @Id");
                data.SetParameter("@Name", modCompany.Name);
                data.SetParameter("@Phone", modCompany.Phone);
                data.SetParameter("@Province", modCompany.Province);
                data.SetParameter("@City", modCompany.City);
                data.SetParameter("@PostalCode", modCompany.PostalCode);
                data.SetParameter("@State", modCompany.IsActive);
                data.SetParameter("@IdUser", modCompany.IdUser);
                data.SetParameter("@Address", modCompany.Address);
                data.SetParameter("@AddressExtra", modCompany.AddressExtra);
                data.SetParameter("@CUIT", modCompany.CUIT);
                data.SetParameter("@Id", modCompany.Id);
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
            AccessData data = new AccessData();
            try
            {   //Se elimina el registro
                data.setQuery("delete from Companies where Id=@Id");
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

        public List<Company> Filter(string searchBy, string state = "3", string filter = "")
        {
            List<Company> list = new List<Company>();
            AccessData data = new AccessData();

            string query = "Select * from Companies where ";

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

                string column = "";
                switch (searchBy)
                {
                    case "Nombre":
                        column = "Name like '%" + filter + "%'";
                        break;

                    case "CUIT":
                        column = "CUIT like '" + filter + "'";
                        break;
                }
                query += column;


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
                    query += " and IsActive= 1";
                }

                else if (state == "Inactivo")
                {
                    query += " and IsActive= 0";
                }


                data.setQuery(query);
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan los articulos de la base
                    Company aux = new Company();
                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.IdUser = Convert.ToInt16(data.Reader["IdUser"]);
                    aux.Name = data.Reader["Name"].ToString();
                    aux.Phone = data.Reader["Phone"].ToString();
                    aux.Address = data.Reader["Address"].ToString();
                    aux.AddressExtra = data.Reader["AddressExtra"].ToString();
                    aux.City = data.Reader["City"].ToString();
                    aux.PostalCode = data.Reader["PostalCode"].ToString();
                    aux.Province = data.Reader["Province"].ToString();
                    aux.CUIT = data.Reader["CUIT"].ToString();
                    aux.IsActive = Convert.ToBoolean(data.Reader["IsActive"]);

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

        public Company GetCompany(string idsearch)
        {
            Company aux = new Company();
            AccessData data = new AccessData();

            try
            {
                data.setQuery("Select * from Companies where Id = '" + idsearch + "';");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 

                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.IdUser = Convert.ToInt16(data.Reader["IdUser"]);
                    aux.Name = data.Reader["Name"].ToString();
                    aux.Phone = data.Reader["Phone"].ToString();
                    aux.Address = data.Reader["Address"].ToString();
                    aux.AddressExtra = data.Reader["AddressExtra"].ToString();
                    aux.City = data.Reader["City"].ToString();
                    aux.PostalCode = data.Reader["PostalCode"].ToString();
                    aux.Province = data.Reader["Province"].ToString();
                    aux.CUIT = data.Reader["CUIT"].ToString();
                    aux.IsActive = Convert.ToBoolean(data.Reader["IsActive"]);

                }

                return aux;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                data.closeConnection();
            }
        }
    }
}
