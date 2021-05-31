using System;
using BoardGame.Library.Concrete.NoughtsAndCrosses;
using BoardGame.Library.Concrete;
using BoardGame.Library.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGame
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<NoughtsAndCrossesGame>().Start();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<IBoard, NoughtsAndCrossesBoard>()
                .AddSingleton<ITextWriter, ConsoleWriter>()
                .AddSingleton<NoughtsAndCrossesGame>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if(_serviceProvider == null)
            {
                return;
            }
            if(_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
