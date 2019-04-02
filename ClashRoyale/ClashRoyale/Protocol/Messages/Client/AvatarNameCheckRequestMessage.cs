﻿using ClashRoyale.Extensions;
using ClashRoyale.Logic;
using ClashRoyale.Protocol.Messages.Server;
using DotNetty.Buffers;

namespace ClashRoyale.Protocol.Messages.Client
{
    public class AvatarNameCheckRequestMessage : PiranhaMessage
    {
        public AvatarNameCheckRequestMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            Id = 14600;
        }

        public string Name { get; set; }

        public override void Decode()
        {
            Name = Reader.ReadScString();
        }

        public override async void Process()
        {
            await new CheckNameChange(Device)
            {
                Name = Name
            }.Send();
        }
    }
}