using Godot;

public partial class ShopMenu : MenuObj
{
	[Export] public CanvasLayer foreground;
	public ShopInventory shop;
	public ShipDoll player;

	[Export] public int buyMulti;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		foreground.Visible = false;
	}


	public void Exchange(bool isBuy, int type)
	{


		int buyerWallet;//buyer money
		int buyer;//buyer stock
		int seller;//seller stock
		int sellerWallet;//seller stock
		int price;//price

		if(isBuy)
		{
			buyerWallet = player.inv[0].count;
			sellerWallet = shop[0].count;
			buyer = player.inv[type].count;
			seller = shop[type].count;
			price = shop[type].buyPrice;
		}else{
			buyer = shop[type].count;
			seller = player.inv[type].count;
			buyerWallet = shop[0].count;
			sellerWallet = player.inv[0].count;
			price = shop[type].SellPrice;
		}

		GD.Print("before:");
		GD.Print(buyer);
		GD.Print(buyerWallet);
		GD.Print(seller);
		GD.Print(sellerWallet);
		GD.Print(price);
		GD.Print("*-----*");

		if(buyerWallet >= price * buyMulti && seller >= buyMulti)
		{
			buyerWallet -= price * buyMulti;
			sellerWallet += price * buyMulti;
			buyer += buyMulti;
			seller -= buyMulti;
		}else{
			int curMulti;
			int canAfford;
			if(price != 0)
			{
				canAfford = buyerWallet / price;
			}else{
				canAfford = 99999;
			}

			GD.Print(buyerWallet);
			GD.Print(price);
			GD.Print(canAfford);

			if(canAfford > seller)
			{
				curMulti = seller;
			}else{
				curMulti = canAfford;
			}

			buyerWallet -= price * curMulti;
			sellerWallet += price * curMulti;
			buyer += curMulti;
			seller -= curMulti;
		}


		if(isBuy)
		{
			player.inv[type].count = buyer;
			player.inv[0].count = buyerWallet;
			shop[0].count = sellerWallet;
			shop[type].count = seller;
		}else{
			player.inv[type].count = seller;
			player.inv[0].count = sellerWallet;
			shop[0].count = buyerWallet;
			shop[type].count = buyer;
		}
	}

	public ShopItem GetShopInv(int type)
	{
		try
		{
		return shop[type];
		}catch{
			if(shop == null)
			{
				GD.Print("Error: Shop Not Set");
			}
			return null;
		}
    }
    public Item GetPlayerInv(int type)
	{
		try
		{
			Item playerItem = player.inv[type];

			if(playerItem == null)
			{
				player.inv.add(new(type,0));
				return player.inv[type];
			}

			return playerItem;
		}catch{
			if(player == null)
			{
				GD.Print("Error: Player Not Set");
			}
			return new(type,0);
		}
	}
	public override void setVisible(bool toState)
	{
		foreground.Visible = toState;
		Visible = toState;
	}
	public void open(ShopInventory inv)
	{
		shop = inv;
		foreground.Visible = true;
		Visible = true;
	}

}
