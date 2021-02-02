package com.capstone.ca;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class DialogListAdapter extends BaseAdapter {

    private String[] listData;

    private LayoutInflater layoutInflater;

    public DialogListAdapter(Context context, String[] listData) {
        this.listData = listData;
        layoutInflater = LayoutInflater.from(context);
    }

    @Override
    public int getCount() {

        return listData.length;
    }

    @Override
    public Object getItem(int position) {
        return listData[position];
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder;
        if (convertView == null) {
            convertView = layoutInflater.inflate(R.layout.list_item_dialog, null);
            holder = new ViewHolder();
            holder.title_text = convertView.findViewById(R.id.title_text);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        holder.title_text.setText(listData[position]);



        return convertView;
    }

    static class ViewHolder {
        TextView title_text;
    }
}