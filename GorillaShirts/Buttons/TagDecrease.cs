﻿using GorillaShirts.Behaviours;
using GorillaShirts.Interaction;
using GorillaShirts.Interfaces;
using GorillaShirts.Models;
using GorillaShirts.Tools;
using System;

namespace GorillaShirts.Buttons
{
    internal class TagDecrease : IStandButton
    {
        public Interaction.ButtonType Type => Interaction.ButtonType.TagDecrease;
        public Action<Main> Function => (Main constructor) =>
        {
            ShirtRig localRig = constructor.LocalRig;

            if (Configuration.CurrentTagOffset.Value > 0)
            {
                Networking networking = constructor.Networking;

                Configuration.CurrentTagOffset.Value--;
                networking.UpdateProperties(networking.GenerateHashtable(localRig.Rig.Shirt, Configuration.CurrentTagOffset.Value));
            }

            Stand shirtStand = constructor.Stand;

            shirtStand.Rig.SetTagOffset(Configuration.CurrentTagOffset.Value);
            shirtStand.Display.SetTag(Configuration.CurrentTagOffset.Value);

            if (localRig.Rig.Shirt != null) localRig.Rig.SetTagOffset(Configuration.CurrentTagOffset.Value);
        };
    }
}
