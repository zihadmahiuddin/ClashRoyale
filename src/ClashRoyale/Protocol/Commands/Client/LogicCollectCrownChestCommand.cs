﻿using ClashRoyale.Logic;
using ClashRoyale.Logic.Home.Chests.Items;
using ClashRoyale.Protocol.Commands.Server;
using ClashRoyale.Protocol.Messages.Server;
using DotNetty.Buffers;

namespace ClashRoyale.Protocol.Commands.Client
{
    public class LogicCollectCrownChestCommand : LogicCommand
    {
        public LogicCollectCrownChestCommand(Device device, IByteBuffer buffer) : base(device, buffer)
        {
        }

        public override async void Process()
        {
            await new AvailableServerCommand(Device)
            {
                Command = new ChestDataCommand(Device)
                {
                    Chest = Device.Player.Home.Chests.BuyChest(1, Chest.ChestType.Crown)
                }
            }.SendAsync();

            Device.Player.Home.Crowns -= 10;
        }
    }
}