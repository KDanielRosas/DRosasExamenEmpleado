using DL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
			ML.Result result = new ML.Result();
			try
			{
				using (DrosasExamenEmpleadoContext context = new())
				{
					int query = context.Database.ExecuteSqlRaw($"EmpleadoAdd " +
						$"'{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}'," +
						$"{empleado.Estado.IdEstado}");

					if (query > 0) { result.Correct = true; }

					else { result.Correct = false; }
				}

			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = ex.Message;
				throw;
			}
			return result;
        }//Add

		public static ML.Result Delete(int idEmpleado)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DrosasExamenEmpleadoContext context = new())
				{
					int query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {idEmpleado}");

					if (query > 0) { result.Correct = true; }

					else { result.Correct = false; }
				}
			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = ex.Message;
				throw;
			}
			return result;
		}//Delete

		public static ML.Result Update(ML.Empleado empleado)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DrosasExamenEmpleadoContext context = new())
				{
					int query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate {empleado.IdEmpleado}, " +
						$"'{empleado.Nombre}', '{empleado.ApellidoPaterno}'," +
						$"'{empleado.ApellidoMaterno}', {empleado.Estado.IdEstado}");

                    if (query > 0) { result.Correct = true; }

                    else { result.Correct = false; }
                }
			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = ex.Message;
				throw;
			}
			return result;
		}//Update

		public static ML.Result GetAll()
		{
			ML.Result result = new();

			try
			{
				using (DrosasExamenEmpleadoContext context = new())
				{
					var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();

					if (query != null)
					{
						result.Objects = new List<object>();

						foreach (var item in query)
						{
							ML.Empleado empleado = new ML.Empleado();
							empleado.IdEmpleado = item.IdEmpleado;
							empleado.NumeroNomina = item.NumeroNomina;
							empleado.Nombre = item.Nombre;
							empleado.ApellidoPaterno = item.ApellidoPaterno;
							empleado.ApellidoMaterno = item.ApellidoMaterno;
							empleado.Estado = new ML.Estado();
							empleado.Estado.IdEstado = item.IdEmpleado;
							empleado.Estado.Nombre = item.EstadoNombre;

							result.Objects.Add(empleado);
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

		public static ML.Result GetById(int idEmpleado)
		{
			ML.Result result = new();

			try
			{
				using (DrosasExamenEmpleadoContext context = new())
				{
					var query = context.Empleados.FromSqlRaw($"EmpleadoGetById {idEmpleado}").AsEnumerable().FirstOrDefault();

					if (query != null)
					{
						ML.Empleado empleado = new ML.Empleado();
						empleado.IdEmpleado = query.IdEmpleado;
						empleado.NumeroNomina = query.NumeroNomina;
						empleado.Nombre = query.Nombre;
						empleado.ApellidoPaterno = query.ApellidoPaterno;
						empleado.ApellidoMaterno = query.ApellidoMaterno;
						empleado.Estado = new ML.Estado();
						empleado.Estado.IdEstado = query.IdEstado.Value;
						empleado.Estado.Nombre = query.EstadoNombre;

						result.Object = empleado;
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