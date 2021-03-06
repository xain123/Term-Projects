﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="styloDatabase")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertItem(Item instance);
    partial void UpdateItem(Item instance);
    partial void DeleteItem(Item instance);
    partial void InsertSale(Sale instance);
    partial void UpdateSale(Sale instance);
    partial void DeleteSale(Sale instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertService(Service instance);
    partial void UpdateService(Service instance);
    partial void DeleteService(Service instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::DAL.Properties.Settings.Default.styloDatabaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Item> Items
		{
			get
			{
				return this.GetTable<Item>();
			}
		}
		
		public System.Data.Linq.Table<Sale> Sales
		{
			get
			{
				return this.GetTable<Sale>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Service> Services
		{
			get
			{
				return this.GetTable<Service>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Item")]
	public partial class Item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _PID;
		
		private int _Price;
		
		private string _Category;
		
		private int _Size;
		
		private string _Color;
		
		private string _Brand;
		
		private string _Date;
		
		private int _Quantity;
		
		private EntitySet<Sale> _Sales;
		
		private EntitySet<Service> _Services;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPIDChanging(string value);
    partial void OnPIDChanged();
    partial void OnPriceChanging(int value);
    partial void OnPriceChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnSizeChanging(int value);
    partial void OnSizeChanged();
    partial void OnColorChanging(string value);
    partial void OnColorChanged();
    partial void OnBrandChanging(string value);
    partial void OnBrandChanged();
    partial void OnDateChanging(string value);
    partial void OnDateChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    #endregion
		
		public Item()
		{
			this._Sales = new EntitySet<Sale>(new Action<Sale>(this.attach_Sales), new Action<Sale>(this.detach_Sales));
			this._Services = new EntitySet<Service>(new Action<Service>(this.attach_Services), new Action<Service>(this.detach_Services));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PID", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string PID
		{
			get
			{
				return this._PID;
			}
			set
			{
				if ((this._PID != value))
				{
					this.OnPIDChanging(value);
					this.SendPropertyChanging();
					this._PID = value;
					this.SendPropertyChanged("PID");
					this.OnPIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Int NOT NULL")]
		public int Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Size", DbType="Int NOT NULL")]
		public int Size
		{
			get
			{
				return this._Size;
			}
			set
			{
				if ((this._Size != value))
				{
					this.OnSizeChanging(value);
					this.SendPropertyChanging();
					this._Size = value;
					this.SendPropertyChanged("Size");
					this.OnSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Color", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				if ((this._Color != value))
				{
					this.OnColorChanging(value);
					this.SendPropertyChanging();
					this._Color = value;
					this.SendPropertyChanged("Color");
					this.OnColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Brand", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Brand
		{
			get
			{
				return this._Brand;
			}
			set
			{
				if ((this._Brand != value))
				{
					this.OnBrandChanging(value);
					this.SendPropertyChanging();
					this._Brand = value;
					this.SendPropertyChanged("Brand");
					this.OnBrandChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_Sale", Storage="_Sales", ThisKey="PID", OtherKey="PID")]
		public EntitySet<Sale> Sales
		{
			get
			{
				return this._Sales;
			}
			set
			{
				this._Sales.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_Service", Storage="_Services", ThisKey="PID", OtherKey="PID")]
		public EntitySet<Service> Services
		{
			get
			{
				return this._Services;
			}
			set
			{
				this._Services.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Sales(Sale entity)
		{
			this.SendPropertyChanging();
			entity.Item = this;
		}
		
		private void detach_Sales(Sale entity)
		{
			this.SendPropertyChanging();
			entity.Item = null;
		}
		
		private void attach_Services(Service entity)
		{
			this.SendPropertyChanging();
			entity.Item = this;
		}
		
		private void detach_Services(Service entity)
		{
			this.SendPropertyChanging();
			entity.Item = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sale")]
	public partial class Sale : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDS;
		
		private string _PID;
		
		private string _Sale_Date;
		
		private EntityRef<Item> _Item;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDSChanging(int value);
    partial void OnIDSChanged();
    partial void OnPIDChanging(string value);
    partial void OnPIDChanged();
    partial void OnSale_DateChanging(string value);
    partial void OnSale_DateChanged();
    #endregion
		
		public Sale()
		{
			this._Item = default(EntityRef<Item>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDS", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IDS
		{
			get
			{
				return this._IDS;
			}
			set
			{
				if ((this._IDS != value))
				{
					this.OnIDSChanging(value);
					this.SendPropertyChanging();
					this._IDS = value;
					this.SendPropertyChanged("IDS");
					this.OnIDSChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string PID
		{
			get
			{
				return this._PID;
			}
			set
			{
				if ((this._PID != value))
				{
					if (this._Item.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPIDChanging(value);
					this.SendPropertyChanging();
					this._PID = value;
					this.SendPropertyChanged("PID");
					this.OnPIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sale_Date", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Sale_Date
		{
			get
			{
				return this._Sale_Date;
			}
			set
			{
				if ((this._Sale_Date != value))
				{
					this.OnSale_DateChanging(value);
					this.SendPropertyChanging();
					this._Sale_Date = value;
					this.SendPropertyChanged("Sale_Date");
					this.OnSale_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_Sale", Storage="_Item", ThisKey="PID", OtherKey="PID", IsForeignKey=true)]
		public Item Item
		{
			get
			{
				return this._Item.Entity;
			}
			set
			{
				Item previousValue = this._Item.Entity;
				if (((previousValue != value) 
							|| (this._Item.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Item.Entity = null;
						previousValue.Sales.Remove(this);
					}
					this._Item.Entity = value;
					if ((value != null))
					{
						value.Sales.Add(this);
						this._PID = value.PID;
					}
					else
					{
						this._PID = default(string);
					}
					this.SendPropertyChanged("Item");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Username;
		
		private string _Password;
		
		private string _Role;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnRoleChanging(string value);
    partial void OnRoleChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="VarChar(50)")]
		public string Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					this.OnRoleChanging(value);
					this.SendPropertyChanging();
					this._Role = value;
					this.SendPropertyChanged("Role");
					this.OnRoleChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Service")]
	public partial class Service : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SID;
		
		private string _PID;
		
		private string _Customer_Name;
		
		private string _Address;
		
		private string _Phone;
		
		private System.Nullable<int> _Charges;
		
		private string _Service_Date;
		
		private string _Return_Date;
		
		private EntityRef<Item> _Item;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSIDChanging(int value);
    partial void OnSIDChanged();
    partial void OnPIDChanging(string value);
    partial void OnPIDChanged();
    partial void OnCustomer_NameChanging(string value);
    partial void OnCustomer_NameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnChargesChanging(System.Nullable<int> value);
    partial void OnChargesChanged();
    partial void OnService_DateChanging(string value);
    partial void OnService_DateChanged();
    partial void OnReturn_DateChanging(string value);
    partial void OnReturn_DateChanged();
    #endregion
		
		public Service()
		{
			this._Item = default(EntityRef<Item>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SID
		{
			get
			{
				return this._SID;
			}
			set
			{
				if ((this._SID != value))
				{
					this.OnSIDChanging(value);
					this.SendPropertyChanging();
					this._SID = value;
					this.SendPropertyChanged("SID");
					this.OnSIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PID", DbType="VarChar(50)")]
		public string PID
		{
			get
			{
				return this._PID;
			}
			set
			{
				if ((this._PID != value))
				{
					if (this._Item.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPIDChanging(value);
					this.SendPropertyChanging();
					this._PID = value;
					this.SendPropertyChanged("PID");
					this.OnPIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Customer_Name", DbType="VarChar(MAX)")]
		public string Customer_Name
		{
			get
			{
				return this._Customer_Name;
			}
			set
			{
				if ((this._Customer_Name != value))
				{
					this.OnCustomer_NameChanging(value);
					this.SendPropertyChanging();
					this._Customer_Name = value;
					this.SendPropertyChanged("Customer_Name");
					this.OnCustomer_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(MAX)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(50)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Charges", DbType="Int")]
		public System.Nullable<int> Charges
		{
			get
			{
				return this._Charges;
			}
			set
			{
				if ((this._Charges != value))
				{
					this.OnChargesChanging(value);
					this.SendPropertyChanging();
					this._Charges = value;
					this.SendPropertyChanged("Charges");
					this.OnChargesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Service_Date", DbType="VarChar(50)")]
		public string Service_Date
		{
			get
			{
				return this._Service_Date;
			}
			set
			{
				if ((this._Service_Date != value))
				{
					this.OnService_DateChanging(value);
					this.SendPropertyChanging();
					this._Service_Date = value;
					this.SendPropertyChanged("Service_Date");
					this.OnService_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Return_Date", DbType="VarChar(50)")]
		public string Return_Date
		{
			get
			{
				return this._Return_Date;
			}
			set
			{
				if ((this._Return_Date != value))
				{
					this.OnReturn_DateChanging(value);
					this.SendPropertyChanging();
					this._Return_Date = value;
					this.SendPropertyChanged("Return_Date");
					this.OnReturn_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_Service", Storage="_Item", ThisKey="PID", OtherKey="PID", IsForeignKey=true)]
		public Item Item
		{
			get
			{
				return this._Item.Entity;
			}
			set
			{
				Item previousValue = this._Item.Entity;
				if (((previousValue != value) 
							|| (this._Item.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Item.Entity = null;
						previousValue.Services.Remove(this);
					}
					this._Item.Entity = value;
					if ((value != null))
					{
						value.Services.Add(this);
						this._PID = value.PID;
					}
					else
					{
						this._PID = default(string);
					}
					this.SendPropertyChanged("Item");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
