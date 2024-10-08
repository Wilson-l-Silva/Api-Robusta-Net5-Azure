﻿using Manager.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        protected User() { }

        // Propriedades
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //Comportamentos
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = Email;
            Validate();
        }

        // Se auto valida
        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new Exception("Alguns campos estão inválidos, por favor corrija-os!" + _errors[0]);
            }

            return true;
        }

    }
}
