using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Inject.Test.Share.Entities;
using Square.Picasso;

namespace Inject.ViewHolders
{
  public class SettingViewHolder : RecyclerView.ViewHolder
  {
    private ImageView iconSetting;
    private TextView textSetting;

    private Picasso picasso;

    public SettingViewHolder(View itemView, Picasso picasso, Action<SettingEntity> listener) : base(itemView)
    {
      if (itemView == null)
      {
        throw new ArgumentNullException(nameof(itemView));
      }

      if (picasso == null)
      {
        throw new ArgumentNullException(nameof(picasso));
      }

      this.picasso = picasso;

      iconSetting = itemView.FindViewById<ImageView>(Resource.Id.IconSetting);
      textSetting = itemView.FindViewById<TextView>(Resource.Id.TextSetting);

      itemView.Click += (sender, e) => listener(boundSetting);
    }

    private SettingEntity boundSetting;

    public void BindToSetting(SettingEntity setting)
    {
      if (setting == null)
      {
        throw new ArgumentNullException(nameof(setting));
      }

      picasso.Load(setting.IconSetting).Into(iconSetting);
      textSetting.Text = setting.TextSetting;

      boundSetting = setting;
    }

  }
}
