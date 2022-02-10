﻿using System;
using System.Collections.Generic;

namespace JKClient {
	//TODO: remake to struct?
	public sealed class ServerInfo {
		public NetAddress Address;
		public string HostName;
		public string MapName;
		public string Game;
		public GameType GameType;
		public int Clients;
		public int MaxClients;
		public int MinPing;
		public int MaxPing;
		public int Ping;
		public bool Visibile;
		public bool NeedPassword;
		public bool TrueJedi;
		public bool WeaponDisable;
		public bool ForceDisable;
		public ProtocolVersion Protocol;
		public ClientVersion Version;
		public bool Pure;
		internal bool InfoSet;
		internal long Start;
		internal void SetInfo(InfoString info) {
			if (info.Count <= 0) {
				return;
			}
			this.Protocol = (ProtocolVersion)info["protocol"].Atoi();
			this.Clients = info["clients"].Atoi();
			this.HostName = info["hostname"];
			this.MapName = info["mapname"];
			this.MaxClients = info["sv_maxclients"].Atoi();
			this.Game = info["game"];
			this.MinPing = info["minPing"].Atoi();
			this.MaxPing = info["maxPing"].Atoi();
			this.InfoSet = true;
		}
		internal void SetConfigstringInfo(InfoString info) {
			if (info.Count <= 0) {
				return;
			}
			this.Protocol = (ProtocolVersion)info["protocol"].Atoi();
			this.HostName = info["sv_hostname"];
			this.MapName = info["mapname"];
			this.MaxClients = info["sv_maxclients"].Atoi();
			this.MinPing = info["sv_minping"].Atoi();
			this.MaxPing = info["sv_maxping"].Atoi();
			this.InfoSet = true;
		}
	}
	public sealed class ServerInfoComparer : EqualityComparer<ServerInfo> {
		public override bool Equals(ServerInfo x, ServerInfo y) {
			return x.Address == y.Address;
		}
		public override int GetHashCode(ServerInfo obj) {
			return obj.Address.GetHashCode();
		}
	}
}
