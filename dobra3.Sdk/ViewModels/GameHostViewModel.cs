using dobra3.Sdk.AppModels;
using dobra3.Sdk.DataModels;
using dobra3.Shared.Utils;

namespace dobra3.Sdk.ViewModels
{
    public sealed class GameHostViewModel : BasePageViewModel, IAsyncInitialize
    {
        private GameStateModel _gameState;
        private QuestionSetDataModel _questions;

        public GameHostViewModel(QuestionSetDataModel questions)
        {
            _questions = questions;
        }

        public Task InitAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
