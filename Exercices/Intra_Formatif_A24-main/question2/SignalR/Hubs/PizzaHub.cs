using Microsoft.AspNetCore.SignalR;
using SignalR.Services;

namespace SignalR.Hubs
{
    public class PizzaHub : Hub
    {
        private readonly PizzaManager _pizzaManager;

        public PizzaHub(PizzaManager pizzaManager) {
            _pizzaManager = pizzaManager;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnConnectedAsync();
        }

        public async Task SelectChoice(PizzaChoice choice)
        {
            _pizzaManager.AddUser();
            Groups.AddToGroupAsync(Context.ConnectionId, _pizzaManager.GetGroupName(choice));
            Clients.Group(_pizzaManager.GetGroupName(choice)).SendAsync("UpdateNbUsers", _pizzaManager.NbConnectedUsers);
            Clients.Caller.SendAsync("UpdatePizzaPrice", _pizzaManager.PIZZA_PRICES[(int)choice]);
            Clients.Group(_pizzaManager.GetGroupName(choice)).SendAsync("UpdateNbPizzasAndMoney", _pizzaManager.Money[(int)choice], _pizzaManager.NbPizzas[(int)choice]);
        }

        public async Task UnselectChoice(PizzaChoice choice)
        {
            _pizzaManager.RemoveUser();
            Groups.RemoveFromGroupAsync(Context.ConnectionId, _pizzaManager.GetGroupName(choice));
        }

        public async Task AddMoney(PizzaChoice choice)
        {
            _pizzaManager.IncreaseMoney(choice);
            Clients.Group(_pizzaManager.GetGroupName(choice)).SendAsync("UpdateMoney", _pizzaManager.Money[(int)choice]);
        }

        public async Task BuyPizza(PizzaChoice choice)
        {
            _pizzaManager.BuyPizza(choice);
            Clients.Group(_pizzaManager.GetGroupName(choice)).SendAsync("UpdateNbPizzasAndMoney", _pizzaManager.Money[(int)choice], _pizzaManager.NbPizzas[(int)choice]);
        }
    }
}
