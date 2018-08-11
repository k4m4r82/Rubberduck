﻿using Rubberduck.SettingsProvider;

namespace Rubberduck.SmartIndenter
{
    public class IndenterConfigProvider : IConfigProvider<IndenterSettings>
    {
        private readonly IPersistanceService<IndenterSettings> _persister;

        public IndenterConfigProvider(IPersistanceService<IndenterSettings> persister)
        {
            _persister = persister;
        }

        public IndenterSettings Create()
        {
            var prototype = new IndenterSettings(false);
            return _persister.Load(prototype) ?? prototype;
        }

        public IndenterSettings CreateDefaults()
        {
            return new IndenterSettings(false);
        }

        public void Save(IndenterSettings settings)
        {
            _persister.Save(settings);
        }
    }
}
