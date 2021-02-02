package com.capstone.ca

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.cardview.widget.CardView
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.recyclerview.widget.RecyclerView
import com.capstone.ca.Models.Employee


class ListAdapter : RecyclerView.Adapter<ListAdapter.ViewHolder> {


    private var selectedPosition: Int=-1
    lateinit var listener:OnItemClickListener
    lateinit var list: ArrayList<Employee>
    lateinit var context: Context
        constructor(
        onItemClickListener: OnItemClickListener,
        list: ArrayList<Employee>,context: Context
    ) {
        this.listener=onItemClickListener
        this.list=list
            this.context=context
    }

    constructor(
        onItemClickListener: OnItemClickListener
    ) {
        this.listener=onItemClickListener
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int, payloads: MutableList<Any>) {
        super.onBindViewHolder(holder, position, payloads)
    }



    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        return ViewHolder(
            LayoutInflater.from(parent.context)
                .inflate(R.layout.list_item, parent, false)
        )
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
//
        if (!isNull(list.get(position).getID()))
            holder.employee_id.setText(""+list.get(position).getID()!!)
        
         holder.employee_name.setText("Name: "+list.get(position).getName()!!)
         holder.employee_department.setText("Department: "+list.get(position).getDepartmentName()!!)
         holder.employee_job.setText("Job: "+list.get(position).getJobName()!!)
         holder.employee_officeLocation.setText("Office: "+list.get(position).getOfficeLocation()!!)
        holder.employee_phone.setText("Phone: "+list.get(position).getCellPhoneNumber()!!)
        holder.employee_email.setText("Email: "+list.get(position).getEmail()!!)

        if (selectedPosition == position) {
            holder.card_employee.setBackgroundColor(
                context.resources.getColor(R.color.darkblue)
            )
            holder.employee_id.setTextColor(context.resources.getColor(R.color.white))
            holder.employee_name.setTextColor(context.resources.getColor(R.color.white))
            holder.employee_department.setTextColor(context.resources.getColor(R.color.white))
            holder.employee_job.setTextColor(context.resources.getColor(R.color.white))
            holder.employee_officeLocation.setTextColor(
                context.resources.getColor(R.color.white)
            )
            holder.employee_phone.setTextColor(
                context.resources.getColor(R.color.white)
            )
            holder.employee_email.setTextColor(
                context.resources.getColor(R.color.white)
            )

            if(isNull(list.get(position).getCellPhoneNumber()))
            {
                holder.iv_call.isEnabled = false
                holder.iv_call.isClickable=false
                holder.iv_call.setBackgroundResource(R.drawable.black_border_layout_fill_gray)

            }else
            {
                holder.iv_call.isEnabled = true
                holder.iv_call.isClickable=true
                holder.iv_call.setBackgroundResource(R.drawable.black_border_layout)
            }

            if(isNull(list.get(position).getEmail()))
            {
                holder.iv_email.isEnabled = false
                holder.iv_email.isClickable=false

                holder.ll_email.setBackgroundResource(R.drawable.black_border_layout_fill_gray)
            }else
            {
                holder.iv_email.isEnabled = true
                holder.iv_email.isClickable=true
                holder.iv_email.setBackgroundResource(R.drawable.black_border_layout)

            }

        } else {
            holder.card_employee.setBackgroundColor(context.resources.getColor(R.color.white))
            holder.employee_id.setTextColor(context.resources.getColor(R.color.black))
            holder.employee_name.setTextColor(context.resources.getColor(R.color.black))
            holder.employee_department.setTextColor(context.resources.getColor(R.color.black))
            holder.employee_job.setTextColor(context.resources.getColor(R.color.black))
            holder.employee_officeLocation.setTextColor(context.resources.getColor(R.color.black))
            holder.employee_phone.setTextColor(context.resources.getColor(R.color.black))
            holder.employee_email.setTextColor(context.resources.getColor(R.color.black))



            holder.iv_call.isEnabled = false
            holder.iv_call.isClickable=false
            holder.iv_call.setBackgroundResource(R.drawable.black_border_layout_fill_gray)


            holder.iv_email.isEnabled = false
            holder.iv_email.isClickable=false
            holder.iv_email.setBackgroundResource(R.drawable.black_border_layout_fill_gray)




        }



        holder.iv_call.setOnClickListener {
            if(!isNull(list.get(position).getCellPhoneNumber()))
            listener.onItemClick(0,position)
        }

        holder.iv_email.setOnClickListener{
            if(!isNull(list.get(position).getEmail()))
            listener.onItemClick(1,position)
        }

        holder.card_employee.setOnClickListener({
            listener.onCardViewClick(position)


        })
        
    }


    fun ifItsEmpty(s: String?, the: String?): String? {
        return if (s == null) the else if (s.isEmpty()) the else s
    }

    fun isNull(`object`: Any?): Boolean {
        return `object` == null
    }


    inner class ViewHolder(itemView: View?) : RecyclerView.ViewHolder(itemView!!) {

        val employee_id=itemView!!.findViewById<TextView>(R.id.employee_id)
        val employee_name=itemView!!.findViewById<TextView>(R.id.employee_name)
        val employee_department=itemView!!.findViewById<TextView>(R.id.employee_department)
        val employee_job=itemView!!.findViewById<TextView>(R.id.employee_job)
        val employee_officeLocation=itemView!!.findViewById<TextView>(R.id.employee_officeLocation)
        val employee_phone=itemView!!.findViewById<TextView>(R.id.employee_phone)
        val employee_email=itemView!!.findViewById<TextView>(R.id.employee_email)

        val iv_email=itemView!!.findViewById<ImageView>(R.id.iv_email)
        val iv_call=itemView!!.findViewById<ImageView>(R.id.iv_call)

        val card_employee=itemView!!.findViewById<ConstraintLayout>(R.id.cl_container)
        val ll_call=itemView!!.findViewById<LinearLayout>(R.id.ll_call)
        val ll_email=itemView!!.findViewById<LinearLayout>(R.id.ll_email)


    }

    fun setSelectedPosition(position: Int) {
        this.selectedPosition = position
    }


    override fun getItemCount(): Int {
        return list.size

    }
}