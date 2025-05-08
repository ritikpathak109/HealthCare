import { Component, OnInit } from '@angular/core';
import { PatientServiceService } from 'src/app/Services/patient-service.service';

@Component({
  selector: 'app-patient-dashboard',
  templateUrl: './patient-dashboard.component.html',
  styleUrls: ['./patient-dashboard.component.css']
})
export class PatientDashboardComponent implements OnInit {
  userName: string | null = '';
  roleName: string | null = '';
  userId: string | null = '';
  patientDetails: any;
  profileImageUrl: string = '';
  imageUrl: string | ArrayBuffer | null = null;

selectedFile: File | null = null;
  constructor(private patientser: PatientServiceService ) {}

  ngOnInit(): void {
    this.userName = localStorage.getItem('userName');
    this.roleName = localStorage.getItem('roleName');
    this.userId = localStorage.getItem('userId');

    if (this.userId) {
      this.loadPatientDetails(this.userId);
      this.loadProfilePicture(this.userId);

    }
  }

  loadPatientDetails(userId: string){
    this.patientser.getPatientDetails(userId).subscribe((res:any)=> {
      this.patientDetails = res[0];
      console.log(this.patientDetails);
      

    });
  }

  loadProfilePicture(userId: string) {
    this.patientser.getProfilePicture(userId).subscribe(response => {
      const reader = new FileReader();
      reader.readAsDataURL(response);
      reader.onloadend = () => {
        this.imageUrl = reader.result;
      };
    });
    
  }
  
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }
  
  uploadPicture() {
    if (this.userId && this.selectedFile) {
      this.patientser.uploadProfilePicture(this.userId, this.selectedFile).subscribe(() => {
        this.loadProfilePicture(this.userId!);
        alert('Profile picture uploaded successfully.');
  
        // Reset file input
        this.selectedFile = null;
        const fileInput = document.getElementById('fileInput') as HTMLInputElement;
        if (fileInput) {
          fileInput.value = ''; 
        }
      });
    }
  }
  
}
