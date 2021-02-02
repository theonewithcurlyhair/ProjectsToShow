<%-- 
    Document   : employee
    Created on : 5-Mar-2020, 8:46:50 PM
    Author     : Mike
--%>
<%@include file="WEB-INF/jspf/taglibraries.jspf" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Employee</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>

        <c:set var="errors" value="${ error }" />
        <c:set var="vm" value="${ vm }" />
        <c:set var="allSkills" value="${ allSkills }" />

        <h1 class="text-center display-4 grey">Employee</h1>
        <section id="cover" class="min-vh-100 form-row justify-content-md-center">
            <div id="cover-caption">
                <form method="POST" action="create">
                    <c:if test="${vm.employee != null && vm.employee.id !=0 }">
                        <p>Employee Id = ${vm.employee.getId()}</p>
                        <input type="hidden" class="form-control" name="id" value="${vm.employee.getId()}">
                    </c:if>
                    <div class="mb-3">
                        <label>Employee first name</label>
                        <input type="text" class="form-control" name="firstName" value="${vm.employee.getFirstName()}" required>
                    </div>
                    <div class="mb-3">
                        <label>Employee last name</label>
                        <input type="text" class="form-control" name="lastName" value="${vm.employee.getLastName()}" required>
                    </div>
                    <label>Employee SIN</label>
                    <input type="text" class="form-control" name="Sin" value="${vm.employee.getSin()}" required>
                    <div class="mb-3"> 
                        <label>Employee Hourly Rate</label>
                        <input type="text" class="form-control" name="hourlyRate" value="${vm.employee.getHourlyRate()}" required>
                    </div>
                    <c:if test="${vm.employee.getCreatedAt() != null}">
                        <p>Employee Created date:<b> ${vm.employee.getCreatedAt()}</b></p>
                    </c:if>
                    <c:if test="${vm.employee.getUpdatedAt() != null}">
                        <p>Employee Updated date:<b> ${vm.employee.getUpdatedAt()}</b></p>
                    </c:if>
                    <p>Please Select skills that this employee posses</p>
                    <c:if test="${vm.employee != null && vm.employee.id !=0 && vm.getTasks() != null && vm.getEmployeeTasks() != null }">
                        <c:forEach items="${vm.getTasks()}" var="allSkills">
                            <div>
                                <div class="form-check form-check-inline">
                                    <input class="form-check-input" type="checkbox" id="${allSkills.getId()}" value="${allSkills.getId()}" name="skills">
                                    <label class="form-check-label" for="${allSkills.getId()}">${allSkills.getName()}</label>
                                </div>
                            </div>
                            <c:forEach items="${vm.getEmployeeTasks()}" var="seletedSkill">
                                <c:if test="${allSkills.getId() == seletedSkill.getId()}">
                                    <script>
                                        document.getElementById(${allSkills.getId()}).checked = true;
                                    </script>
                                </c:if>

                            </c:forEach>
                        </c:forEach>
                    </c:if>
                    <c:if test="${vm == null}">
                        <c:forEach items="${allSkills}" var="allSkills">
                            <div>
                                <div class="form-check form-check-inline">
                                    <input class="form-check-input" type="checkbox" id="${allSkills.getId()}" value="${allSkills.getId()}" name="skills">
                                    <label class="form-check-label" for="${allSkills.getId()}">${allSkills.getName()}</label>
                                </div>
                            </div>
                        </c:forEach>
                    </c:if>
                    <c:if test="${vm != null}">
                        <input class="btn btn-lg btn-outline-dark" type="submit" value="update" name="action" />
                        <a href="#myModal" class="trigger-btn" data-toggle="modal">
                            <input class="btn btn-lg  btn-outline-dark" type="submit" value="delete" name="action" />
                        </a>
                    </c:if>
                    <c:if test="${vm == null}">
                        <input class="btn btn-lg btn-outline-dark" type="submit" value="create" name="action" />
                    </c:if>
            </div>
        </form>
        <div class="mt-5">
            <c:choose>
                <c:when test="${ vm.employee.errors.size() > 0 }">
                    <ul class="alert alert-danger">
                        <c:forEach items="${ vm.employee.errors }" var="err">
                            <li>Error Code: ${ err.code } Error Desc: ${err.description }</li>
                            </c:forEach>
                    </ul>
                </c:when>
                <c:when test="${ error!=null }">
                    <ul class="alert alert-danger">
                        <c:forEach items="${ error.errors }" var="err">
                            <li>${ err }</li>
                            </c:forEach>
                    </ul>
                </c:when>
            </c:choose>
        </div>
    </section>
    <c:if test="${vm.employee != null && vm.employee.id !=0 }">
        <!-- Modal HTML -->
        <div id="myModal" class="modal fade">
            <div class="modal-dialog modal-confirm h-100 d-flex flex-column justify-content-center my-0">
                <form method="POST" action="delete">
                    <div class="modal-content">
                        <div class="modal-header">			
                            <h4 class="modal-title">Are you sure?</h4>	
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <p>Do you really want to delete this record? This process cannot be undone.</p>
                            <input type="hidden" class="form-control" name="id" value="${vm.employee.getId()}">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-info" data-dismiss="modal">Cancel</button>
                            <button type="submit" value="delete" name="action" class="btn btn-danger">Delete</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </c:if>
    <%@include file="WEB-INF/jspf/footer.jspf" %>
</body>
</html>