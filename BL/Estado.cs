using DL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DrosasExamenEmpleadoContext context = new())
                {
                    var query = context.Estados.FromSqlRaw("EstadoGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = item.IdEstado;
                            estado.Nombre = item.Nombre;
                            result.Objects.Add(estado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//GetAll

        public static ML.Result GetById(int idEstado)
        {
            ML.Result result = new();

            try
            {
                using (DrosasExamenEmpleadoContext context = new())
                {
                    var query = context.Estados.FromSqlRaw($"EstadoGetById {idEstado}").AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Estado estado = new();
                        estado.IdEstado = query.IdEstado;
                        estado.Nombre = query.Nombre;
                                                
                        result.Object = estado;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//GetById
    }//Class
}//NS
