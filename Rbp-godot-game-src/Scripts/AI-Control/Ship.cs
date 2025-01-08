using Godot;
using Godot.Collections;
using System;

public partial class Ship : CharacterBody2D
{
			 public SceneMan manager;
			 public Global global; 
    [Export] public string ID;

	[Export] public shipModelData data;
			 public ShipSave save;
			 public shipInput input;

	[Export] public string ShipModelID;
	[Export] public inventory inv;
	[Export] public cannonData activeCannon;
			 public float dir;
    		 public float gunState = 0;
			 public float sailState;
			 public float speed;

	[Export] public status stat;


	//#--------------------#
	//#   Regular Funcs    #
	//#--------------------#
    public override void _Ready()
    {
		assignID();//here so that ID assignment occurs after loading (if from save) to maintain ID consistiantsy across sessions
    }
    public override void _Process(double delta)
    {
		input.update(delta);
    }
    public override void _PhysicsProcess(double delta)
	{
		if(!manager.pausedScene)
		{
			if(activeCannon != null && input.isFireCannon()){  FireCannons(activeCannon, input.getCannonTarget());  }

			TurnShip(input.getTurnDir(), delta);
			CommandSail(input.getSailCom(), delta);

			Velocity = calcVel(delta);
			MoveAndSlide();

			speed = GetPositionDelta().Length() * 3600;
			gunState -= (float)delta;

		}
	}

	public virtual void preLoad(SceneMan man)
	{
		manager = man;
		global = manager.global;
/*
		save = new(this);

		input.start();
		input.setShip(this);
		*/
	}
	//#--------------------#
	//#     Data Fucs      #
	//#--------------------#

	public Vector2 getCannonOffset(float dir)
	{
		if(dir >= 0)
		{
		return new() 
		{
			X = data.cannonOffset.X,
			Y = data.cannonOffset.Y
		};
		}else
		{
		return new() 
		{
			X = -data.cannonOffset.X,
			Y = -data.cannonOffset.Y
		};
		}
	}

	public shipModelData getData()
	{
		return data;
	}

	public Vector2 calcVel(double delta)
	{
		if(input.getAncorState())
		{
			speed *= 0.95f;
			//return new Vector2(0,0);
		}

		speed += sailState * data.Acc;//<=======================TODO: ADD WIND/CURRENT CLAC HERE
		speed = Math.Clamp(speed, data.Minspeed, data.Maxspeed);


		Vector2 vel = new()
        	{
        	    X = (float)(Math.Sin(dir * (Math.PI / 180)) * speed * delta),
        	    Y = (float)(Math.Cos(dir * (Math.PI / 180)) * speed * delta)
        	};



		return vel;
	}
	//#--------------------#
	//#     Ship Control   #
	//#--------------------#

	public void TurnShip(float turnStrength, double delta)
	{
		dir += Math.Clamp(turnStrength, -1, 1) * data.TurnAcc * (float)delta;
		dir = (dir + 360) % 360;
	}
	public void CommandSail(float sailTarget, double delta)
	{
		sailState += sailTarget * (float)delta * data.SailAcc;
		sailState = Math.Clamp(sailState, 0, 1);
	}

	public void FireCannons(cannonData cannon, Vector2 target)
	{
		if(gunState <= 0)
		{
			GD.Print("shot dir: " + Global.Vec2toDir(target));

			string ShotPath = ResourceUid.GetIdPath(ResourceUid.TextToId(cannon.cannonBallUUID));

			CannonBall shot = (CannonBall)ResourceLoader.Load<PackedScene>(ShotPath).Instantiate();

			shot.Specs = (MunitionRes)cannon.ammoData.Duplicate(true);
			shot.Dir = Global.Vec2toDir(target);
			shot.Speed = cannon.ammoSpeed;
			shot.FSMomentium = Velocity;

			Vector2 offset = getCannonOffset(dir);

			shot.Position = new()
        	{
        	    X = (float)Math.Sin(dir * (Math.PI / 180)) + Position.X + offset.X,
        	    Y = (float)Math.Cos(dir * (Math.PI / 180)) + Position.Y + offset.Y 
        	};

			GetParent().AddChild(shot);
			shot.preLoad();
			gunState = data.gunCooldown;
		}else{
			GD.Print("cannon Is too hot" + gunState);
		}

	}

	//#--------------------#
	//# World Interactions #
	//#--------------------#
	public void pickUpEntered(Area2D area)
	{
		GD.Print(area.Name);
		if(area.Name == "Loot")
		{
			getLoot(area.GetParent<LootFloat>());
		}

	}
	public void getLoot(LootFloat loot)
	{
		loot.inv.flushInItems();

		inv += loot.inv;
		GD.Print(inv.Count);
		GD.Print(loot.inv.Count);


		loot.QueueFree();
	}

	public void sink()
	{
		//create loot Float (LF)
		LootFloat lf = new();
		//move LF to cur pos
		lf.Position = Position;
		//LF w/h cur inv
		lf.inv = inv;
		//kill self		
		QueueFree();

	}

	//#--------------------#
	//#   ID Management    #
	//#--------------------#

	public string TryAssignID(string inID)
	{
		ID = inID;
		assignID();
		return null;
	}
	public void assignID()
	{
		if(ID != null)
		{
			if(!global.IDCordinator.requestID(ID))
			{
				ID = global.IDCordinator.getNew();
			}
		}
	}

	//#--------------------#
	//#   Statuses fucs    #
	//#--------------------#

	public void healthCheck()
	{
		if(stat.health == 0)
		{
			//Die();
		}
	}

	public int Damage(int inDam)//damages ship, returnes actuial damage taken
	{
		if(stat.health < inDam)
		{
			inDam = stat.health;//reuse of inDam var as output
			stat.health = 0;
		}else{
		stat.health -= inDam;
		}
		return inDam;
	}
	public int heal(int inHeal)//heals ship, returnes actuial health given
	{
		if(data.maxHealth < (inHeal + stat.health))
		{
			inHeal = data.maxHealth - stat.health;//reuse of inHeal var as output
			stat.health = data.maxHealth;
		}else{
		stat.health += inHeal;
		}
		return inHeal;
	}

}
