using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Dollar.Authentication.Services
{
    public class TypeImporter<T>
    {
        // ReSharper disable once UnassignedField.Compiler
        [ImportMany] private IEnumerable<Lazy<T>> _imports;

        public TypeImporter()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public IEnumerable<Lazy<T>> GetImports()
        {
            return _imports;
        }
    }
}