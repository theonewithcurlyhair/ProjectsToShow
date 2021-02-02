package com.capstone.ca

import android.app.Activity
import android.app.AlertDialog
import android.app.Dialog
import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.text.InputType
import android.util.DisplayMetrics
import android.view.View
import android.view.WindowManager
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.capstone.ca.API.webServiceApi
import com.capstone.ca.Models.Department
import com.capstone.ca.Models.Employee
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.activity_main.*
import okhttp3.OkHttpClient
import okhttp3.logging.HttpLoggingInterceptor
import org.json.JSONException
import org.json.JSONObject
import retrofit2.Retrofit
import retrofit2.Retrofit.Builder
import retrofit2.adapter.rxjava2.RxJava2CallAdapterFactory
import retrofit2.converter.gson.GsonConverterFactory
import java.lang.reflect.Type
import java.security.SecureRandom
import java.security.cert.CertificateException
import java.security.cert.X509Certificate
import java.util.*
import javax.net.ssl.*


class MainActivity : AppCompatActivity(),OnItemClickListener,OnDepartmentItemClickListener{

    lateinit var  employee:  ArrayList<Employee>

//    lateinit var  employeeByDepartment:  ArrayList<Employee>
    lateinit var  department:  ArrayList<Department>
    lateinit var api: Retrofit
    lateinit var departmentDialog:Dialog
    lateinit var listAdapter : ListAdapter

//    lateinit var employeelistAdapter : ListAdapter


    val departmentListAdapter : DepartmentsListAdapter by lazy {
        DepartmentsListAdapter(this,department,this)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        api = Builder()
            .baseUrl("https://10.0.2.2:44333/api/")
            .addConverterFactory( GsonConverterFactory.create())

            .addCallAdapterFactory(RxJava2CallAdapterFactory.createWithScheduler(Schedulers.io()))
            .client( getUnsafeOkHttpClient()!!.build())
            .build()


        getAllEmployees()



        filter_icon.setOnClickListener(
            {
                showDialogOrderBy()
            }
        )


    }


    fun getAllEmployees()
    {
        api.create(webServiceApi::class.java).getAllEmployees()!!
            .subscribeOn(Schedulers.io() ).
            observeOn(AndroidSchedulers.mainThread())
            .subscribe({

                val gson = Gson()
                val listType: Type = object : TypeToken<ArrayList<Employee?>?>() {}.getType()
                employee = gson.fromJson(it!!, listType)
                listAdapter=ListAdapter(this,employee,this)
                val layoutManager: RecyclerView.LayoutManager = LinearLayoutManager(this)
                recyclerView.setLayoutManager(layoutManager)
                recyclerView.setAdapter(listAdapter)
                if(employee.size==0)
                    no_record_found.visibility=View.VISIBLE
                else
                    no_record_found.visibility=View.GONE

            },{
                no_record_found.visibility=View.GONE
            })
    }

    fun getUnsafeOkHttpClient(): OkHttpClient.Builder? {
        return try {
            // Create a trust manager that does not validate certificate chains
            val trustAllCerts: Array<TrustManager> = arrayOf<TrustManager>(
                object : X509TrustManager {
                    @Throws(CertificateException::class)
                    override fun checkClientTrusted(
                        chain: Array<X509Certificate?>?,
                        authType: String?
                    ) {
                    }

                    @Throws(CertificateException::class)
                    override fun checkServerTrusted(
                        chain: Array<X509Certificate?>?,
                        authType: String?
                    ) {
                    }
//
                    override fun getAcceptedIssuers(): Array<X509Certificate> {
                        return arrayOf<java.security.cert.X509Certificate>()
                    }

                }
            )

            // Install the all-trusting trust manager
            val sslContext = SSLContext.getInstance("SSL")
            sslContext.init(null, trustAllCerts, SecureRandom())

            // Create an ssl socket factory with our all-trusting manager
            val sslSocketFactory: SSLSocketFactory = sslContext.socketFactory
            val builder = OkHttpClient.Builder()
            val logging = HttpLoggingInterceptor()
            // set your desired log level
            logging.level = HttpLoggingInterceptor.Level.BODY
            builder.addInterceptor(logging)
            builder.sslSocketFactory(sslSocketFactory, trustAllCerts[0] as X509TrustManager)
            builder.hostnameVerifier(object : HostnameVerifier {
               override fun verify(hostname: String?, session: SSLSession?): Boolean {
                    return true
                }
            })
            builder
        } catch (e: Exception) {
            throw RuntimeException(e)
        }
    }



    private fun showDialogOrderBy() {
        val dialog = Dialog(this)
        dialog.setCancelable(true)
        val view: View = layoutInflater.inflate(R.layout.dialog_list, null)
        dialog.setCanceledOnTouchOutside(true)
//        val lv = view.findViewById<ListView>(R.id.list_view)

        val et_search = view.findViewById<EditText>(R.id.et_search)
        val iv_search = view.findViewById<ImageView>(R.id.iv_search)
        val radio_gr=view.findViewById<RadioGroup>(R.id.radio_gr)
        val showDepartments = view.findViewById<TextView>(R.id.show_by_departments)
        showDepartments.setOnClickListener{
            dialog.dismiss()
            getAllDepartments()
        }
        var searchById=true
        radio_gr.setOnCheckedChangeListener(object : RadioGroup.OnCheckedChangeListener {
           override fun onCheckedChanged(group: RadioGroup?, checkedId: Int) {
                when (checkedId) {
                    R.id.radio0 -> {
                        searchById=true
                        et_search.setInputType(InputType.TYPE_CLASS_NUMBER);
                    }
                    R.id.radio1 -> {
                        searchById=false
                        et_search.setInputType(InputType.TYPE_CLASS_TEXT);
                    }
                }
            }
        })

        iv_search.setOnClickListener({
            if (!isNull(et_search.editableText.toString()) && et_search.editableText.toString().length!=0)
            {

               if(searchById)
               {
                   if (et_search.editableText.toString().length!=8)
                   {
                       et_search.setError("ID must be 8 digits.")
                   }else
                   {
                       dialog.dismiss()
                       getEmployeeById(et_search.editableText.toString().toInt())
                   }
               }
                else
               {
                   dialog.dismiss()
                   getEmployeeByLastName(et_search.editableText.toString())
               }
            }
            else
                et_search.setError("Enter ID or LastName")
        })

//        val values = resources.getStringArray(R.array.orderBy)
//        val adapter = DialogListAdapter(this, values)
//        lv.adapter = adapter
//        lv.onItemClickListener =
//            AdapterView.OnItemClickListener { adapterView, view, i, l ->
//
//                if(values[i].equals("ID"))
//                {
//                    Collections.sort(employee, object:Comparator<Employee> {
//                        override fun compare(u1:Employee, u2:Employee):Int {
//                            return u1.getID()!!.compareTo(u2.getID()!!)
//                        }
//
//                    })
//                    listAdapter.notifyDataSetChanged()
//
//                }else if (values[i].equals("Department"))
//                {
//                    Collections.sort(employee, object:Comparator<Employee> {
//                        override fun compare(u1:Employee, u2:Employee):Int {
//
//                            if (isNull(u1.getDepartments()) && isNull(u2.getDepartments()))
//                                return 0;
//                            else
//                                return ifItsEmpty(u1.getDepartments()!!.getName(),"-")!!.compareTo(ifItsEmpty(u2.getDepartments()!!.getName(),"-")!!)
//
//                        }
//                    })
//                    listAdapter.notifyDataSetChanged()
//                }else if (values[i].equals("LastName"))
//                {
//                    Collections.sort(employee, object:Comparator<Employee> {
//                        override fun compare(u1:Employee, u2:Employee):Int {
//                            return ifItsEmpty(u1.getLName(),"-")!!.compareTo(ifItsEmpty(u2.getLName(),"-")!!)
//                        }
//
//                    })
//                    listAdapter.notifyDataSetChanged()
//                }
//
//                dialog.dismiss()
//            }
        dialog.setContentView(view)
        customizeDialog(dialog,1)
        dialog.show()
    }

    private fun getEmployeeById(id:Int)
    {

        api.create(webServiceApi::class.java).searchEmployeeById(id)
            .subscribeOn(Schedulers.io() ).
            observeOn(AndroidSchedulers.mainThread())
            .subscribe({

                val gson = Gson()
                val listType: Type = object : TypeToken<ArrayList<Employee?>?>() {}.getType()
                employee = gson.fromJson(it!!, listType)
                listAdapter=ListAdapter(this,employee,this)
                recyclerView.setAdapter(listAdapter)
                if(employee.size==0)
                    no_record_found.visibility=View.VISIBLE
                else
                    no_record_found.visibility=View.GONE

            },{
                no_record_found.visibility=View.GONE
            })
    }

    private fun getEmployeeByLastName(lastname:String)
    {

        api.create(webServiceApi::class.java).searchEmployeeByLastName(lastname)
            .subscribeOn(Schedulers.io() ).
            observeOn(AndroidSchedulers.mainThread())
            .subscribe({

                val gson = Gson()
                val listType: Type = object : TypeToken<ArrayList<Employee?>?>() {}.getType()
                employee = gson.fromJson(it!!, listType)
                listAdapter=ListAdapter(this,employee,this)
                recyclerView.setAdapter(listAdapter)
                if(employee.size==0)
                    no_record_found.visibility=View.VISIBLE
                else
                    no_record_found.visibility=View.GONE

            },{
                no_record_found.visibility=View.GONE
            })
    }

    private fun getAllDepartments()
    {

        api.create(webServiceApi::class.java).getDepartments()!!
            .subscribeOn(Schedulers.io() ).
            observeOn(AndroidSchedulers.mainThread())
            .subscribe({

                val gson = Gson()
                val listType: Type = object : TypeToken<ArrayList<Department?>?>() {}.getType()
                department= gson.fromJson(it!!, listType)
                var departmentObj=Department()
                departmentObj.setName("All")
                departmentObj.setDepartmentID(-1)
                department.add(0,departmentObj)

                showDepartmentsDialog()


            },{
                no_record_found.visibility=View.GONE
            })


    }
    private fun showDepartmentsDialog() {
        departmentDialog = Dialog(this)
        departmentDialog.setCancelable(true)
        val view: View = layoutInflater.inflate(R.layout.departments_dialog, null)
        departmentDialog.setCanceledOnTouchOutside(true)
        val recyclerView = view.findViewById<RecyclerView>(R.id.recyclerView)

        val layoutManager: RecyclerView.LayoutManager = LinearLayoutManager(this)
        recyclerView.setLayoutManager(layoutManager)
        recyclerView.setAdapter(departmentListAdapter)

        departmentDialog.setContentView(view)
        customizeDialog(departmentDialog,0)
        departmentDialog.show()
    }

    protected fun customizeDialog(dialog: Dialog,type: Int) {
        // Get screen width and height in pixels
        val displayMetrics = DisplayMetrics()
        windowManager.defaultDisplay.getMetrics(displayMetrics)
        // The absolute width of the available display size in pixels.
        val displayWidth = displayMetrics.widthPixels
        // The absolute height of the available display size in pixels.
        val displayHeight = displayMetrics.heightPixels

        // Initialize a new window manager layout parameters
        val layoutParams = WindowManager.LayoutParams()

        // Copy the alert dialog window attributes to new layout parameter instance
        layoutParams.copyFrom(dialog.window.attributes)

        // Set the alert dialog window width and height
        // Set alert dialog width equal to screen width 90%
        val dialogWindowWidth = (displayWidth * 1f).toInt()
        // Set alert dialog height equal to screen height 90%
        // int dialogWindowHeight = (int) (displayHeight * 0.9f);

        // Set alert dialog width equal to screen width 70%
        // int dialogWindowWidth = (int) (displayWidth * 06f);
        // Set alert dialog height equal to screen height 70%
        var dialogWindowHeight = 0
        if(type==0)
            dialogWindowHeight = (displayHeight * 0.7f).toInt()
        else if (type==1)
            dialogWindowHeight = (displayHeight * 0.4f).toInt()
        // Set the width and height for the layout parameters
        // This will bet the width and height of alert dialog
        layoutParams.width = dialogWindowWidth
        layoutParams.height = dialogWindowHeight

        // Apply the newly created layout parameters to the alert dialog window
        dialog.window.attributes = layoutParams
    }

    override fun onItemClick(type: Int,position :Int) {
        if (type==0)
            callNumber(this,employee.get(position).getCellPhoneNumber()!!)
           // ConfirmationDialog("Are you sure you want to call this person",0,position)
        else if (type==1)
            showDialogEmailDialog(position)
            //ConfirmationDialog("Are you sure you want to send email to this person",1,position)

    }

    override fun onCardViewClick(position: Int) {
        listAdapter.setSelectedPosition(position)
        listAdapter.notifyDataSetChanged()
    }

    fun callNumber(activity: Activity, phone: String) {
        val intent = Intent(Intent.ACTION_DIAL)
        intent.data = Uri.parse("tel:$phone")
        activity.startActivity(intent)
    }

    fun ConfirmationDialog(msg:String,type:Int,position: Int)
    {
        val builder = AlertDialog.Builder(this)
        builder.setTitle("Confirmation")
        builder.setMessage(msg)
        //builder.setPositiveButton("OK", DialogInterface.OnClickListener(function = x))

        builder.setPositiveButton("Confirm") { dialog, which ->
            if (type==0)
                callNumber(this,employee.get(position).getCellPhoneNumber()!!)
            else if (type==1)
                showDialogEmailDialog(position)
        }

        builder.setNegativeButton("Cancel") { dialog, which ->

        }

        builder.show()
    }
    fun sendEmail(
        activity: Activity,
        mailTo: String?,
        subject: String?,
        body: String?
    ) {
        val send = Intent(Intent.ACTION_SENDTO)
        val uriText = "mailto:" + Uri.encode(mailTo) +
                "?subject=" + Uri.encode(subject) +
                "&body=" + Uri.encode(body)
        val uri = Uri.parse(uriText)
        send.data = uri
        activity.startActivity(
            Intent.createChooser(send, "Send mail...")
        )
    }

    private fun showDialogEmailDialog(position: Int) {
        val dialog = Dialog(this)
        dialog.setCancelable(true)
        val view: View = layoutInflater.inflate(R.layout.send_email_dialog, null)
        dialog.setCanceledOnTouchOutside(true)
        val send_email_btn = view.findViewById<Button>(R.id.send_email_btn)
        val to_email = view.findViewById<EditText>(R.id.et_toemail)
        val email_subject = view.findViewById<EditText>(R.id.et_subject)
        val email_body = view.findViewById<EditText>(R.id.et_email_body)
        to_email.setText(employee.get(position).getEmail())
        send_email_btn.setOnClickListener({
                sendEmail(this,to_email.editableText.toString(),email_subject.editableText.toString().replace(""," ")
                    ,email_body.editableText.toString().replace(""," "))
        })

        dialog.setContentView(view)
        customizeDialog(dialog,0)
        dialog.show()
    }

    fun isNull(`object`: Any?): Boolean {
        return `object` == null
    }



    override fun onItemClick(position: Int) {


        departmentDialog.dismiss()

        if (department.get(position).getDepartmentID()!=-1)
        {
            api.create(webServiceApi::class.java).getEmployeeByDepartmentsId(department.get(position).getDepartmentID()!!)
                .subscribeOn(Schedulers.io() ).
                observeOn(AndroidSchedulers.mainThread())
                .subscribe({

                    val gson = Gson()
                    val listType: Type = object : TypeToken<ArrayList<Employee?>?>() {}.getType()
                    employee = gson.fromJson(it!!, listType)
                    listAdapter=ListAdapter(this,employee,this)
                    recyclerView.setAdapter(listAdapter)
                    if(employee.size==0)
                        no_record_found.visibility=View.VISIBLE
                    else
                        no_record_found.visibility=View.GONE

                },{
                    no_record_found.visibility=View.GONE
                })
        }
        else
        {
            getAllEmployees()
        }


    }
}
