using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class ShopMenu : Control
{
	public ShopInventory shop;
	public ShipDoll player;

	[Export]
	public int buyMulti;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Exchange(bool isBuy, string type)
	{
		int buyerWallet;//buyer money
		int buyer;//buyer stock
		int seller;//seller stock
		int sellerWallet;//seller stock
		int price;//price

		if(isBuy)
		{
			buyerWallet = player.inv["Money"];
			sellerWallet = shop.inv["Money"];
			buyer = player.inv[type];
			seller = shop.inv[type];
			price = shop.buy[type];
		}else{
			buyer = shop.inv[type];
			seller = player.inv[type];
			buyerWallet = shop.inv["Money"];
			sellerWallet = player.inv["Money"];
			price = shop.sell[type];
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
			player.inv[type] = buyer;
			player.inv["Money"] = buyerWallet;
			shop.inv["Money"] = sellerWallet;
			shop.inv[type] = seller;
		}else{
			player.inv[type] = seller;
			player.inv["Money"] = sellerWallet;
			shop.inv["Money"] = buyerWallet;
			shop.inv[type] = buyer;
		}
	}

	public int GetShopInv(string type, int valState)
	{
        return valState switch
        {
            0 => shop.inv[type],
            1 => shop.buy[type],
            2 => shop.sell[type],
            _ => 0,
        };
    }
    public int GetPlayerInv(string type)
	{
		return player.inv[type];
	}

}
