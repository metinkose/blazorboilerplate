﻿//Autogenerated from IdentityServerDtos.tt
using IdentityServer4.Models;
using ObjectCloner.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BlazorBoilerplate.Shared.Dto.Admin
{
    public partial class ApiResourceDto : ApiResource, IMementoDto
    {
        private object state;

        public void SaveState()
        {
            state = this.DeepClone();
        }

        public void RestoreState()
        {
            if (state != null)
                foreach (PropertyInfo property in GetType().GetProperties().Where(p => p.CanWrite))
                    property.SetValue(this, property.GetValue(state, null), null);
        }
        public void ClearState()
        {
            state = null;
        }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string UserClaimsText
        {
            get => JoinLines(UserClaims);
            set => UserClaims = SplitLines(value);
        }
        private ICollection<string> SplitLines(string value)
        {
            return Regex.Split(value, @"\s+|;|,").Where(i => i != string.Empty).ToArray();
        }
        private string JoinLines(IEnumerable<string> value)
        {
            return string.Join('\n', value);
        }
    }
}
