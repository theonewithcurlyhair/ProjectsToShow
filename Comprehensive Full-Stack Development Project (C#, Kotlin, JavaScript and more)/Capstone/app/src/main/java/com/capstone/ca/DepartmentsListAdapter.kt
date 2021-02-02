package com.capstone.ca

import android.content.Context
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.RelativeLayout
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.recyclerview.widget.RecyclerView
import com.capstone.ca.Models.Department
import com.capstone.ca.Models.Employee


class DepartmentsListAdapter : RecyclerView.Adapter<DepartmentsListAdapter.ViewHolder> {


    lateinit var listener:OnDepartmentItemClickListener
    lateinit var list: ArrayList<Department>
    lateinit var context: Context
        constructor(
        onItemClickListener: OnDepartmentItemClickListener,
        list: ArrayList<Department>,context: Context
    ) {
        this.listener=onItemClickListener
        this.list=list
            this.context=context
    }

    constructor(
        onItemClickListener: OnDepartmentItemClickListener
    ) {
        this.listener=onItemClickListener
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int, payloads: MutableList<Any>) {
        super.onBindViewHolder(holder, position, payloads)
    }



    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        return ViewHolder(
            LayoutInflater.from(parent.context)
                .inflate(R.layout.list_item_dialog, parent, false)
        )
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {

        holder.text.setText(list.get(position).getName())
        holder.rl_container.setOnClickListener{
            listener.onItemClick(position)
        }

    }


    inner class ViewHolder(itemView: View?) : RecyclerView.ViewHolder(itemView!!) {

        val text=itemView!!.findViewById<TextView>(R.id.title_text)
        val rl_container=itemView!!.findViewById<RelativeLayout>(R.id.rl_container)


    }

    override fun getItemCount(): Int {
        return list.size

    }
}