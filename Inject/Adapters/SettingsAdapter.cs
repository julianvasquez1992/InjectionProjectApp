using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Inject.Test.Share.Entities;
using Inject.ViewHolders;
using Square.Picasso;

namespace Inject.Adapters
{
  public class SettingsAdapter : RecyclerView.Adapter
  {
    public event EventHandler<SettingEntity> SettingSelected;

    private List<SettingEntity> settings;

    private Context owner;

    private LayoutInflater layoutInflater;

    private Picasso picasso;

    public SettingsAdapter(Context owner, Picasso picasso)
    {
      if (owner == null)
      {
        throw new NullReferenceException($"Null value in: {nameof(SettingsAdapter)}");
      }

      if (picasso == null)
      {
        throw new NullReferenceException($"Null value in: {nameof(SettingsAdapter)}");
      }

      this.picasso = picasso;
      this.owner = owner;

      settings = new List<SettingEntity>();
      layoutInflater = LayoutInflater.From(owner);
    }

    public override int ItemCount => settings.Count;

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
      var setting = settings[position];
      var viewHolder = holder as SettingViewHolder;
      viewHolder.BindToSetting(setting);
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
      var view = layoutInflater.Inflate(Resource.Layout.SettingsItemLayout, parent, false);

      var viewHolder = new SettingViewHolder(view, picasso, OnSettingSelectedClick);

      return viewHolder;
    }

    private void OnSettingSelectedClick(SettingEntity setting)
    {
      if (SettingSelected != null)
      {
        SettingSelected(this, setting);
      }

    }

    public void AddSettings(List<SettingEntity> listSettings)
    {
      settings.AddRange(listSettings);
      NotifyItemInserted(settings.Count);
    }

    public void ClearAlbums()
    {
      settings.Clear();
      NotifyDataSetChanged();
    }
  }
}
