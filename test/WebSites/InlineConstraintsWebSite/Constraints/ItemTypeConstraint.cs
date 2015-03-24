﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;

namespace InlineConstraintsWebSite.Constraints
{
    public class ItemTypeConstraint : IRouteConstraint
    {
        private readonly string _itemName;

        public ItemTypeConstraint(string itemName)
        {
            _itemName = itemName;
        }

        public bool Match(
            HttpContext httpContext,
            IRouter route,
            string routeKey,
            IDictionary<string, object> values,
            RouteDirection routeDirection)
        {
            object value;

            if (values.TryGetValue(routeKey, out value))
            {
                var valueAsString = value as string;

                if (string.Equals(_itemName, valueAsString, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}