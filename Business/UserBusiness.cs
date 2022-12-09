using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Data;
using Domain;


namespace Business
{
    public class UserBusiness
    {
        public User GetUser(string email, string pw)
        {
            User aux = new User();
            AccessData data = new AccessData();

            data.setQuery("Select * from Users where Email = '" + email + "' and Password = '" + pw + "';");
            data.executeQuery();

            while (data.Reader.Read())
            {
                //Se cargan los productos de la base // Se deberian verificar nulls? 

                aux.Id = Convert.ToInt16(data.Reader["ID"]);
                aux.Email = data.Reader["Email"].ToString();
                aux.Password = data.Reader["Password"].ToString();
                aux.Permission = Convert.ToInt16(data.Reader["Permission"]);
                aux.IsActive = Convert.ToBoolean(data.Reader["IsActive"]);

            }

            return aux;
        }
        public List<User> Show()
        {
            List<User> list = new List<User>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los users 
                data.setQuery("Select * from Users where IsActive = true");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    User aux = new User();
                    aux.Id = Convert.ToInt16(data.Reader["Id"]);
                    aux.Email = data.Reader["Email"].ToString();
                    aux.Password = data.Reader["Password"].ToString();
                    aux.Permission = Convert.ToInt16(data.Reader["Permission"]);
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

        public void Add(User newUser)
        {
            //Se abre la conexión a DB
            AccessData datos = new AccessData();

            try
            {   //Se inserta en DB los data cargados 
                datos.setQuery("Insert into Users (Email, Password, Permission, IsActive) values ('" + newUser.Email + "','" + newUser.Password + "'," + newUser.Permission + "," + newUser.IsActive + ");");
                datos.executeQuery();
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

        public void Modify(User modifiedUser)
        {

            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {
                data.setQuery($"UPDATE Users u SET u.Email = @Email, u.Password = @Password, u.Permission = @Permission, u.IsActive = @State WHERE u.Id = @Id");
                data.SetParameter("@Email", modifiedUser.Email);
                data.SetParameter("@Password", modifiedUser.Password);
                data.SetParameter("@Permission", modifiedUser.Permission);
                data.SetParameter("@State", modifiedUser.IsActive);
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

        public void Delete(int id) //TODO: verificar si es necesaria baja logica del User también
        {
            AccessData datos = new AccessData();
            try
            {   //Se elimina el registro
                datos.setQuery($"UPDATE Companies c SET c.IsActive=0 WHERE IdUser=@Id"); //NO... BAJA LOGICA
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

        public User GetUser(int idsearch)
        {
            User aux = new User();
            AccessData data = new AccessData();

            data.setQuery("Select * from Users where Id = '" + idsearch + "';");
            data.executeQuery();

            while (data.Reader.Read())
            {
                //Se cargan los productos de la base // Se deberian verificar nulls? 

                aux.Id = Convert.ToInt16(data.Reader["Id"]);
                aux.Email = data.Reader["Email"].ToString();
                aux.Password = data.Reader["Password"].ToString();
                aux.Permission = Convert.ToInt16(data.Reader["Permission"]);
                aux.IsActive = Convert.ToBoolean(data.Reader["IsActive"]);

            }

            return aux;
        }

        /*public List<User> Filter(string searchBy, string when, string filter)
        {
            List<User> list = new List<User>();
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
                    aux.Id = (int)data.Reader["Id"];
                    aux.Name = (string)data.Reader["Name"];
                    aux.LastName = (string)data.Reader["LastName"];
                    aux.password = (string)data.Reader["Password"];
                    aux.idCompany = (int)data.Reader["IdCompany"];
                    aux.email = (string)data.Reader["Email"];
                    aux.Phone = (string)data.Reader["Phone"];
                    aux.category = (int)data.Reader["Category"];
                    aux.State = (bool)data.Reader["Active"];

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
            
        }*/
    }
}