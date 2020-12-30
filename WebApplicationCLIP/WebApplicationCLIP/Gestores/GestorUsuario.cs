﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.BD;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.Gestores
{
    public class GestorUsuario
    {

        public bool consultarCredencialesUsuario(string nombreUsuario, string contraseña)
        {
            Usuario usu = Usuario.CrearUsuarioConNombreDeUsuario(nombreUsuario);
            Usuario temp;
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            try
            {
                temp = usuarioDAO.consultar(usu);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (temp.Contraseña != contraseña)
            {
                Console.WriteLine("Contraseña invalida para el usuario '" + temp.NombreDeUsuario + "'");
                return false;
            }
            return true;
        }


      /*  public void registrarUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña)
        {
            try
            {
                Usuario usuarioNuevo = Usuario.nuevoUsuario(dni, nombre, apellido, nombreDeUsuario, email, telefono, contraseña);
                UsuarioDAO usuarioDAO = new UsuarioDAO();
            }
            catch (Exception e)
            {
                throw e;
            }
        }*/

        public void registrarUsuario(Usuario usuarioNuevo)
        {
            try
            {
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.registrar(usuarioNuevo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario consultarUsuarioPorDNI(string DNI)
        {
            Usuario temp = Usuario.CrearUsuarioConDNI(DNI);
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            try
            {
                Usuario usu = usuarioDAO.consultar(temp);
                return usu;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static Usuario consultarUsuarioPorNombreDeUsuario(string nombre)
        {
            Usuario temp = Usuario.CrearUsuarioConNombreDeUsuario(nombre);
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            try
            {
                Usuario usu = usuarioDAO.consultar(temp);
                return usu;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}