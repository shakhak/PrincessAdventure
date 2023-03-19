﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrincessAdventure
{
	public enum InteractionTypes
    {
        Jump,
        MinorChest,
        Talk,
        Door,
        MajorChest

    }

    public class Interactable
    {
        public int interactableId;
        public InteractionTypes type;
        public int relatedId;
        public Vector2 requiredDirection;
    }

    public enum PickUps
    {
        RedPotion,
        BluePotion,
        GreenPotion,
        Key,
        Coin,
        SilverBar,
        GoldBar,
        StarShard
    }
}
