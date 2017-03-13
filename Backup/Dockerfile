FROM openshift/base-centos7
# Dockerfile for a database backup pod.

# install PostgreSQL client programs
RUN yum -y install postgresql

copy backup.sh .
RUN /bin/bash -c 'backup.sh'



