﻿using Incidences.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidences.Data
{
    public interface ICredentialsData
    {
        public Credentials SelectCredentialsById(int id);
        public Credentials SelectCredentialsByUsername(string username);
        public bool CheckCredentials(string username);
        public bool CheckCredentials(string username, string password);
        public bool UpdateCredentials(CredentialsDto credentials, int employeeId);
        public bool UpdateUsername(string username, int employeeId);
        public bool UpdatePassword(string password, int employeeId);
        public bool InsertCredentials(CredentialsDto credentials, int? employeeId);
    }
}
