using System;
using System.Collections.Generic;
using EZBall.Settings;

namespace EZBall.Main
{
    internal sealed class Main : IMain
    {
        private readonly Lazy<View> view;
        private readonly IEnumerable<IPlanet> planets;

        internal Main(Lazy<View> view, IEnumerable<IPlanet> planets)
        {
            this.view = view;
            this.planets = planets;
        }

        public IObservable<IPlanet> Run()
        {
            return this.view.Value.OnClick(this.planets);
        }

        public void Show()
        {
            this.view.Value.Show();
        }

        public void Hide()
        {
            if (this.view.IsValueCreated)
            {
                this.view.Value.Hide();
            }
        }
    }
}