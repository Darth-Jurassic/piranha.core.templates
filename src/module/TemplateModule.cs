﻿using Piranha;
using Piranha.Extend;
using Piranha.Manager;
using Piranha.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateModule
{
    public class TemplateModule : IModule
    {
        private readonly List<PermissionItem> _permissions = new List<PermissionItem>
        {
            new PermissionItem { Name = Permissions.TemplateModule, Title = "List TemplateModule content", Category = "TemplateModule", IsInternal = true },
            new PermissionItem { Name = Permissions.TemplateModuleAdd, Title = "Add TemplateModule content", Category = "TemplateModule", IsInternal = true },
            new PermissionItem { Name = Permissions.TemplateModuleEdit, Title = "Edit TemplateModule content", Category = "TemplateModule", IsInternal = true },
            new PermissionItem { Name = Permissions.TemplateModuleDelete, Title = "Delete TemplateModule content", Category = "TemplateModule", IsInternal = true }
        };

        /// <summary>
        /// Gets the module author
        /// </summary>
        public string Author => "";

        /// <summary>
        /// Gets the module name
        /// </summary>
        public string Name => "";

        /// <summary>
        /// Gets the module version
        /// </summary>
        public string Version => Utils.GetAssemblyVersion(GetType().Assembly);

        /// <summary>
        /// Gets the module description
        /// </summary>
        public string Description => "";

        /// <summary>
        /// Gets the module package url
        /// </summary>
        public string PackageUrl => "";

        /// <summary>
        /// Gets the module icon url
        /// </summary>
        public string IconUrl => "/manager/PiranhaModule/piranha-logo.png";

        public void Init()
        {
            // Register permissions
            foreach (var permission in _permissions)
            {
                App.Permissions["PiranhaModule"].Add(permission);
            }

            // Add manager menu items
            Menu.Items["PiranhaModule"].Items.Add(new MenuItem
            {
                InternalId = "PiranhaModule",
                Name = "PiranhaModule",
                Route = "~/manager/PiranhaModule",
                Policy = Permissions.TemplateModule,
                Css = "fas fa-box"
            });
        }
    }
}
