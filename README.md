# 6BUIS007C-n - Business Information Systems Project

The following is a report written as part of my final year project. A pdf version can be found in the repository, which I would highly recommend over the markdown version below.

![image](https://user-images.githubusercontent.com/79659647/175183140-42942792-436f-4ecb-bbdf-68170cf203ab.png)

**A project undertaken as part of the BSc (Hons) Business Information
Systems Degree, Westminster International University in Tashkent.**

> Name: Khurshidjon Mannopov  
> Email: <kmannopov@gmail.com>  
> Course: BSc (Hons) Business Information Systems  
> Name of Supervisor: Dilshod Ibragimov  
> Date of Submission: 15 April, 2022  

# Acknowledgements

 *"There is no such thing as a \"self-made man\". We are made up of
 thousands of others. Everyone who has ever done a kind deed for us, or
 spoken one word of encouragement to us, has entered into the makeup of our character and of our thoughts, as well as our
 success."*

 ― George Matthew Adams

 I'd like to take this opportunity to quickly thank: my family, for
 their unconditional belief in me and my potential; my friends, for
 their unwavering support through thick and thin; and *all* of my
 lecturers at WIUT, both for the knowledge that they imparted on me and
 the effort they put in to do so.

 # Table of Contents

- [Acknowledgements](#acknowledgements)

- [Glossary](#glossary)

- [Abstract](#abstract)

  1. [Introduction](#introduction)  
  2. [Background](#background)  
  2.1. [Problem Overview](#problem-overview)  
  2.1.1. [Root Cause(s)](#root-causes)  
  2.1.2. [Economic and Social Detriment of the Current System](#economic-and-social-detriment-of-the-current-system)  
  2.2. [Aims and Objectives](#aims-and-objectives)  
  2.2.1. [General Intent/Guidelines (Macro-Economic and Social Scale)](#general-intentguidelines-macro-economic-and-social-scale)  
  2.2.2. [Business Objectives (Micro-Economic Scale)](#business-objectives-micro-economic-scale)  
  2.2.3. [Academic Objectives](#academic-objectives)  
  2.2.4. [Technical Objectives](#technical-objectives)  
  2.2.5. [Personal Objectives](#personal-objectives)  
  2.3. [Project Scope](#project-scope)  
  3. [Business Methodology](#business-methodology)  
  3.1. [Identifying the Target Audience](#identifying-the-target-audience)  
  3.2. [Industry Analysis](#industry-analysis)  
  3.2.1. [PESTLE](#pestle)  
  3.2.2. [SWOT Analysis](#swot-analysis)  
  3.2.3. [Porter's Five Forces](#porters-five-forces)  
  3.3. [Monetization](#monetization)  
  3.3.1. [Choosing the Correct Model](#choosing-the-correct-model)  
  4. [Computing Methodology](#computing-methodology)  
  4.1. [Justification of Hardware/Software Used](#justification-of-hardwaresoftware-used)  
  4.1.1. [User Platform](#user-platform)  
  4.1.2. [Hosting Platform](#hosting-platform)  
  4.1.3. [Backend Server Programming Language/Framework](#backend-server-programming-languageframework)  
  4.1.4. [Database Server](#database-server)  
  4.1.5. [Frontend Mobile Application Programming Language/Framework](#frontend-mobile-application-programming-languageframework)  
  4.2. [Software Architecture](#software-architecture)  
  4.3. [Data Structure](#data-structure)  
  4.4. [Activity Flow](#activity-flow)  
  4.5. [Development Lifecycle](#development-lifecycle)  
  4.6. [Tasks](#tasks)  
  5. [Results](#results)  
  5.1. [Testing](#testing)  
  6. [Conclusion](#conclusion)  
  7. [Final Chapter](#final-chapter)  
  7.1. [Self-Assessment](#self-assessment)  
  7.2. [Limitations](#limitations)  
  7.3. [Future Improvements](#future-improvements)  
  [Reference List](#reference-list)  

# Glossary

 Outpatient care - any healthcare consultation, procedure, treatment,
 or other service that is administered without an overnight stay in a
 hospital or medical facility. Routine physical examinations with a
 primary care provider are one common type of outpatient care.

 EMR - An electronic (digital) collection of medical information about
 a person that is stored on a computer.

 OECD -- The Organization for Economic Co-operation and Development is
 an intergovernmental economic organization with 38 member countries,
 founded in 1961 to stimulate economic progress and world trade.

# Abstract

 The healthcare sector in Uzbekistan is a rapidly developing industry,
 both in terms of size and technological advancement. Certain economic
 factors, however, continue to hinder progress and pose a significant
 challenge for the infrastructure upgrades that are required to improve
 the medical system of the country. The proposed solution, AppointMed,
 an online appointment booking system, attempts to improve one piece of
 the puzzle by streamlining and expediting a routine process in the
 healthcare industry. The design choices and methodology take into
 consideration the fundamental challenges faced by the industry, and
 attempt to create a solution which is economically viable. The
 development process was conducted over the course of this past
 academic year, and aimed to reach all of the objectives set in the
 beginning of the project. The mobile application that was developed
 did manage to meet the targeted scope and feature set, although it's
 important to note that certain modifications had to be made to the
 initial plans. Specifically, due to delays in the development process,
 the initial scope of the application had to be scaled back, and
 certain features had to be backlogged. All in all, the project proved
 to be an insightful experience into the areas of idea creation, market
 research and analysis, and the software development lifecycle.

# Introduction

 The technological revolution of the past few decades has fundamentally
 changed healthcare as we know it. Breakthroughs in the fields of
 biomedicine and medical technology have saved countless lives and
 founds cures and treatments to ailments once thought to be
 untreatable. These developments, as well as their application,
 however, often overshadow the developments within a different, much
 more mundane and routine part of healthcare: a visit to the doctor. A
 2019 study (Michas, F.) found that the average number of annual
 doctor's visits among OECD countries can vary from 2.3 to over 17
 times per person. The start of the digital age promised one of the
 first overhauls of the healthcare industry: the computerization of
 medical records. Even in as far back as 1988, researchers such as
 McDonald et. al. (1988) predicted that "over the next few years,
 computer stored medical records will become technically and
 economically feasible on a broad scale." While the full
 computerization of medical records would not start until the 2000's
 (even in highly economically and technologically advanced countries
 such as the United States) it shows the potential application of new
 technology that was seen from the very beginning. Nowadays, widespread
 adoption of the internet and the low barriers to entry to smartphones
 have created new possibilities for convenience within every aspect of
 life, including healthcare. The project undertaken in this report aims
 to utilize one such convenience made possible by technology: managing
 doctor appointments online, and searching for a reputable healthcare
 provider based on a patient's own needs.

2.  # Background

    1.  ## Problem Overview

 An Uzbekistan Healthcare Sector Report conducted by RB Asia in 2019
 found that the government of Uzbekistan allocated \$1.27bn of the
 national budget towards the healthcare sector. At the time, that
 figure was expected to increase to nearly \$3.5bn by the year 2022,
 with their 10-year forecast predicting that the budget allocation
 towards healthcare would reach

 \$7.19bn by the year 2029. While this does show that the sector is
 growing at a rapid pace, the country still has a long way to go in
 terms of utilizing technology to assist the day-to-day processes of
 outpatient care. In fact, a study conducted by Asadov and Aripov
 (2009) concluded that the Uzbek healthcare system, among a number of
 post-soviet countries, had poorly equipped

 medical facilities, and that local Quality Improvement projects often
 fail to address factors that directly support the quality of
 healthcare. As an example, we can observe this in the country's
 failure to adopt a nationwide electronic medical record system,
 despite the fact that numerous studies, including one conducted by
 Wang et. al. (2002) concluded that the implementation of an EMR system
 can result in a positive financial return on investment to healthcare
 providers. Such a counter-intuitive approach often results in a
 diminished quality of care for patients, and an unnecessarily
 difficult workload for healthcare providers and doctors alike.

### Root Cause(s)

 The aforementioned problems are not, however, without cause. While the
 overall scope of the challenges facing the Uzbek healthcare system is
 too big to encompass within this report, we will be taking a look at
 arguably the biggest factor that is hindering the technological
 development and adoption within the industry: economic and financial
 limitations.

 A study conducted by the World Health Organization (Ahmedov et. al.,
 2014) analyzed the healthcare sector of Uzbekistan, it's transition to
 a post-soviet system, and the challenges currently facing the sector.
 They concluded that "some of the greatest challenges relate to health
 financing", and the fact that the government allocates a small portion
 of its comparatively low GDP results in substantial private
 expenditure for patients. When government funding is not sufficient,
 and patients are required to pay out of pocket for their care, it
 becomes evident why adopting even the most basic modern infrastructure
 developments, such as an EMR, for example, are massive hurdles for
 healthcare providers.

 Furthermore, this issue can also be attributed to the relatively low
 purchasing power of the general population. While Uzbekistan's
 Purchasing Power Parity measurement is not available as of writing
 this report, a GDP per Capita of \$6,880, only 40% of the world
 average, combined with a Gini Coefficient (an index measuring wealth
 inequality, ranging from 0 to 1, from least to most inequal,
 respectively) of 0.35 can paint a clear picture of the situation at
 hand. When the local population does not have the financial power or
 motive to sustain an increase in the price of healthcare, and when
 healthcare providers are not adequately funded, it is difficult to
 achieve substantial growth in terms of infrastructure development and
 technological adoption.

### Economic and Social Detriment of the Current System

 Referring back to the study conducted by the WHO, Ahmedov and
 colleagues (2014) argued that there was a strong business case for
 improving the user experience of the healthcare system.

 They pointed out that many medical providers in the country lacked the
 frameworks for appointment scheduling, and that the system was
 characterized by long wait times and multiple return visits. While
 concrete data on the user experience of patients of public medical
 providers in the country are non-existent, a survey collected in 2010
 conducted in 9 post-soviet countries found that on average, 60% of
 users were not satisfied with their respective healthcare system
 (Footman et. al., 2013).

 In addition, long appointment wait-times have been shown to result in
 substantial economic losses in the form of wages and productivity. A
 study conducted by the Frasier Institute (2021), for example, found
 that Canadian patients as a whole, over the course of their entire
 treatment, lost between an estimated \$2.8bn and \$8.4bn in wages.
 This is compounded when we consider the loss of productivity as a
 result of having to take more time off of work.

## Aims and Objectives

 Having defined the problem at hand, analyzed the root causes, and
 outlined the disadvantages of the current system, we can specify the
 objectives of the project that will directly address the issues
 mentioned above.

### General Intent/Guidelines (Macro-Economic and Social Scale)

 Note, that the points mentioned below are general guidelines aimed at
 reflecting the *ethos* of the project, and are meant to be interpreted
 as a reflection of some of the wider potential implications and
 benefits of developing and utilizing such an application. They *are
 not* metrics with which the success of the project will be measured by
 (those are listed further below under Business, Technical, and
 Personal Objectives).

-   Develop an appointment booking framework which will *partially*
    address the current inefficiency of the healthcare system in
    Uzbekistan

-   Improve the user experience of outpatient care for the general
    population

-   Mitigate *some* of the economic detriment caused by the shortcomings
    of the current system

-   Present the benefits of, and promote the widespread use and adoption
    of technology within the healthcare sector

-   Reduce some of the "hassle" of visiting the doctor in an effort to
    promote and increase the number of regular visits

2.  ### Business Objectives (Micro-Economic Scale)

    -   Develop a financially sustainable and viable appointment booking
        framework which can be integrated into the current systems of
        medical providers with ease

    -   Analyze different monetization options and select one that
        results in the lowest costs for both patients and medical
        providers alike

    -   Analyze the different platforms available for development
        (mobile, web, etc.), and select one that results in the largest
        reach to customers

    -   Define the target user demographic

3.  ### Academic Objectives

    -   Analyze the general state of the current healthcare system of
        Uzbekistan

    -   Outline the shortcomings, inefficiencies, and issues facing the
        healthcare system

    -   Identify the root causes of said issues

    -   Develop a potential solution supported by the research that has
        been conducted

    -   Analyze the results of the solution and come to a conclusion on
        its potential viability in a real-world environment

4.  ### Technical Objectives

 Develop a mobile application that allows users to:

-   View a list of nearby medical providers

-   Search for a medical provider based on their specific requirement

-   Select a medical provider, a doctor, and book an appointment based
    around the schedule of the selected doctor

-   Check into an appointment, notifying the doctor

-   Cancel an appointment, if the need arises

-   View a list of previous appointments

In addition, a back-end REST API server must be created, which can:

-   Securely store user authentication and appointment scheduling data

-   Securely retrieve and send user data to the mobile application

-   Implement authentication

-   Implement authorization to ensure proper data access rules

-   Be able to perform with a high number of users

-   Implement a scalable software architecture to ensure easier
    long-term development

5.  ### Personal Objectives

    -   Develop an application that can be used within a portfolio to
        showcase my experience and skills with modern OOP languages

    -   Follow industry standard 'best practices' during the development
        phase

    -   Learn how to plan a project and manage time effectively

    -   Learn a new programming language and mobile application
        development framework, in the form of Flutter and Dart

    -   Challenge myself to create an application of a size and scale on
        which I have not worked on before

## Project Scope

 It is important to define the limits of both what the application is
 supposed to do, and what it is capable of evolving into in the future.

 The appointment booking system, consisting of a front-end mobile
 application, and a back-end REST API will consist of the following
 functionality:

 Patient-side:

1.  View a list of local clinics based on the type of medical
    specialization required.

2.  Select a clinic and view details (including a location on a map), as
    well as a list of doctors within the selected department.

3.  Select a doctor, view their details, and view a list of available
    appointment times for that doctor.

4.  Select an appropriate date and time and schedule the appointment.

5.  Check in to the appointment after reaching the clinic.

6.  View a list of both scheduled appointments as well as previously
    completed appointments.

7.  Cancel an upcoming appointment.

8.  Create and update an individual User Profile.

 Doctor-side:

1.  View both a list of upcoming appointments and previous appointment
    history.

2.  Be notified of upcoming appointments, and once users have checked in
    to their appointment.

3.  Change the status of appointments to "Complete".

4.  Cancel appointments.

5.  Create and update an individual User Profile.

 Backend server is responsible for:

1.  User authentication in the form of Json Web Tokens

2.  User authorization and restricted endpoints

3.  Registration of both user types

4.  Persistence of user profiles, clinic details, appointment details on
    a database

5.  Retrieval of patients, doctors, clinics, appointments from the
    database

 Features which can be implemented in the future (but outside the scope
 of the current project):

-   Messaging feature between doctors and patients

-   Test result collection

-   Review system for medical providers and doctors

-   Payment system

3.  # Business Methodology

    1.  ## Identifying the Target Audience

 In 'Target Market Identification and Data Collection Methods', Curtis
 and Allen (2018) argue that the first step in defining a target
 audience is "identifying its key characteristics, such as
 demographics, psychographics, and products/services the target market
 wants and values".

 Note, that in this instance, the psychographics of the target audience
 does not play a significant role. The service being offered is
 utilitarian, and the underlying product behind it, a visit to the
 doctor, is a necessity for everyone regardless of their individual or
 collective psychographics.

 We can identify our market demographics for patients using the
 following criteria:

 Age: 18-65. Limiting age is important, as an audience younger than 18
 is under the provision of their parents (who are older than 18), and
 an audience over 65 is less likely to own a smartphone (O' Dea, 2021),
 or possess the technical skills to be able to take full advantage of
 the application.

 Geographic Location: Uzbekistan.

 Race, Religion, Gender, Income Level, Family Size, Occupation,
 Education Level, Marital Status: Any.

 The target demographics for corporate users, in this case Medical
 Providers, will be more nuanced:

 Industry: Healthcare.

 Sector: Both Public and Private Company Type: Medical Provider.
 Company Size: Any.

 Yearly Revenue: Any. Geographic Location: Uzbekistan.

2.  ## Industry Analysis

    1.  ### PESTLE
    
    **Political:**  

 Since its independence from the Soviet Union, the government of 
 Uzbekistan has introduced a number of political reforms aimed
 at improving the healthcare systems of the country, although
 the implications of these reforms on healthcare quality have
 been called into question (Asadov and Aripov, 2009).
 Nevertheless, the government has approved and undertaken
 multiple initiatives aimed at improving healthcare access and
 quality (Ahmedov et. al., 2014):                                
                                                                 
 -   1998--2004: Project Health, funded by the World Bank        
                                                                 
 -   2005--2012: Project Health II, funded by the World Bank     
                                                                 
 -   2005--2012: Project on Woman and Child Health Development,  
     funded by the Asian Development Bank                        
                                                                 
 -   2012--2018: Project Health III, funded by the World Bank    
                                                                 
 In addition, a number of presidential decrees aimed at
 outlining the direction of the health reforms have been signed: 
                                                                 
 -   2007: Presidential Decree No. 3923                          
                                                                 
 -   2007: Presidential Edict No. 700                            
                                                                 
 -   2011: Presidential Decree No. 1652                          
                                                                 
 Overall, the political landscape is one that is supportive of
 decentralizing and partially privatizing the industry. Projects
 such as this one, which are aimed at improving the quality and
 user experience of healthcare would likely avoid political
 pushback.                                                       

   **Economical:**  

 The economic situation in this context is somewhat complicated.
 As mentioned above, while the government is increasing the
 budget allocation towards the sector, it falls short by the
 standards of more developed countries, and is insufficient in
 funding even the most essential operations on a nationwide
 scale. In addition, it has also been identified that, in
 general, the local population is likely incapable of driving
 technological innovation and growth through sheer demand. In
 addition, financial access to medical care has been impeded
 through the rise of informal charges in the country. According
 to a World Health Organization estimate, in 2021, out of pocket
 informal payments accounted for almost half of the total health
 expenditures (WHO Regional Office for Europe, 2021). Health
 Expenditure per Capita was also below the average for Central
 Asia (WHO Regional Office for Europe, 2021).
                                                                 
 This largely leaves the technological development of the sector
 at the hands of private medical providers, and government
 projects and initiatives specifically targeted at
 making the necessary infrastructure upgrades.
 
   **Social:**  

 As with any product, there are a number of factors that can
 affect the choice of a patient when choosing a medical
 provider. A review on these factors conducted by Kolstad and
 Chernew (2009) have suggested that patients look for
 "convenient, generally well-qualified, and responsive primary
 care physicians". Based on this finding, we can infer that
 convenience and responsiveness, two important factors of the
 user experience, play a crucial role in determining patient
 satisfaction, and subsequently affecting their choice of
 healthcare provider. The average user experience of public
 medical providers in Uzbekistan is categorized as one with long
 queue times, and multiple return visits (Ahmedov et. al.,
 2014). While there is little empirical data surrounding the
 general population's perception of the healthcare system, we
 can infer, based on previous findings, that it is inadequate in terms of   
 efficiency and quality.  

   **Technological:**  

 The technology used both in specialized care and general visits
 are limited both in terms of quality and volume. According to
 the aforementioned WHO study (Ahmedov et. al., 2014) health
 systems in Uzbekistan have been slow to adopt and utilize the
 benefits of information technologies. In fact, the use of IT in
 state owned and operated facilities is constricted to basic
 electronic data entry and collection. While certain private
 medical providers, such as "Shox International Hospital" and
 "Horev Medical Center" advertise the proliferation of IT within
 their operations, and offer services such as online test result
 collection, these providers are limited to urban areas and
 patients who are both willing and capable of paying for                  
 higher-than-average medical costs.  

   **Legal:**  

 Companies operating in Uzbekistan and handling the personal
 data of Uzbek citizens must store their data on servers located
 within the country, according to Article 27-1 of the law. In
 addition, highly sensitive data, including medical records,
 must be stored securely to avoid potential liability in the event of a data    
 breach.                                                         


### SWOT Analysis
  
|              | **Strengths**                                                                                                                                                                                                                                                          | **Weaknesses**                                                                                                                                                                                                                                 |
|--------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Internal** | Streamlines a process that everyone routinely partakes in                                                                                                                                                                                                              | Limited feature set.                                                                                                                                                                                                                           |
|              | Saves time for doctors, lowers wait times for patients                                                                                                                                                                                                                 | Business model fundamentally relies on reaching critical mass before widespread adoption. Medical providers may hesitate to implement a system with a small userbase, userbase will not expand unless there is a variety of medical providers. |
|              | Eliminates the need for doctors to use their own system of remembering and tracking appointments                                                                                                                                                                       | Requires re-training of doctors and administrative staff                                                                                                                                                                                       |
|              | Can provide insightful and accurate analytics for medical providers                                                                                                                                                                                                    |                                                                                                                                                                                                                                                |
|              | Low cost of entry for medical providers                                                                                                                                                                                                                                |                                                                                                                                                                                                                                                |
| **External** | Concept has been proven to work in other countries                                                                                                                                                                                                                     | Limited reach due to low smartphone penetration                                                                                                                                                                                                |
|              | Lack of competitors offering an identical service                                                                                                                                                                                                                      | User resistance to accept product                                                                                                                                                                                                              |
|              | Growing national healthcare sector                                                                                                                                                                                                                                     | Reluctance on the part of medical providers to store patient information and analytical data, on external systems                                                                                                                              |
|              | Growing technological adoption and digitalization of medical services                                                                                                                                                                                                  | Potential legal liability when working with sensitive data on this scale                                                                                                                                                                       |
|              | Government incentives for “ensuring sustainable improvement of health indicators of the country's population and level of satisfaction with the national health system determined in accordance with universally recognized international practices." (RP-3894, 2018)  |                                                                                                                                                                                                                                                |


### Porter's Five Forces

![image](https://user-images.githubusercontent.com/79659647/175262725-0845dcba-6cf5-4059-8eee-946d970e2403.png)

 **Competition in the Industry**

 There are several competitors within the healthcare industry of
 Uzbekistan offering a somewhat similar product:

1.  Private Medical Providers: "Horev Medical Center" offers users the
    ability to sign up for an appointment on their website. This
    functionality, however, is limited to only providing the center with
    the user's contact information. Once provided, the medical center's
    staff call the user to get more details on the type of appointment
    needed, and the date and time of the appointment. While the system
    does partially use an online component, the majority of the work is
    done manually over the phone, meaning they offer a completely
    different value proposition with this service. The website does not
    allow the user to choose a specific type of doctor, nor a date and
    time for the appointment.

2.  Certain Individual Public Medical Providers: The Republican
    Specialized Scientific Practical Medical Center of Hematology offers
    users the ability to choose a specific doctor, date, and time, for
    an appointment on their website. The core functionality of this
    service is extremely similar to the application being developed.
    However, there are a number of limitations which this product faces:
    the service is limited to only this specific
    medical center, and the fact that the Center of Hematology is an
    extremely specialized facility limits users in terms of the type of
    care they can receive.

3.  Ministry of Health's website: In late 2020, it was reported by
    Sputnik News that the Uzbekistan Ministry of Health launched a
    website for an online queuing system for the family polyclinics of
    Tashkent. As of writing this report in 2022, 2 years after the
    launch, their website at
    [[https://reg.ssv.uz/]{.underline}](https://reg.ssv.uz/) still
    returns an error message to the user. Evaluation of the service and
    its potential threat as a competitor could not be conducted due to
    the fact that the service does not work.

 To summarize, while several different parties have attempted to launch
 similar and competing products, their offerings are either
 fundamentally limited in scope and functionality, or do not work as
 intended. A service offering the exact or close to exactly the same
 functionality does not yet exist. Therefore, competition within this
 industry in Uzbekistan is low.

 **Threat of New Entrants**

 As previously discussed, the government is actively encouraging the
 development of the IT sphere in the healthcare sector. While this is
 beneficial for developing an appointment scheduling system, it also
 increases the risk of other competitors entering the industry. As an
 example, in a recent project called "100 Ideas for Uzbekistan"
 sponsored by the Ministry of Innovation Development (among other
 sponsors), 12 of the 100 winning proposals were in the sphere of
 healthcare (2021). One specific project called "E-Med", proposed by a
 WIUT student, was concerned with digitizing medical records into a
 nationwide system. While this concept is not directly in competition
 with the project being developed in this report, it can still
 highlight how active encouragement of development within this sphere
 leads to a high threat of new entrants.

 This, in combination with the fact that appointment booking systems
 are "tried and true" frameworks, means that there is a possibility
 that certain businesses may have already explored and planned an
 entrance, and are simply waiting for the right market conditions to do
 so.

 **Power of Suppliers**

 In the case of a mobile application, where a physical good is not
 sourced or sold, the role of the supplier would be the tools and
 frameworks used in the development process, and any services used to
 maintain the application. Throughout the entire *development* process,
 no paid products

 were used. In fact, the only cost associated with the project would be
 the hosting platform used to host the back-end API server. Given the
 large number of hosting providers, and the option to purchase
 dedicated server equipment to self-host the application, the power of
 suppliers in this instance would be low.

 **Power of Customers**

 According to Porter (1979), a buyer group is powerful if:

-   It's concentrated

-   It purchases in large volumes

-   The product it purchases is undifferentiated

-   The product does not save the buyer money

 With these criteria, we can determine that our customer groups,
 patients and medical providers, both hold low to moderate power as
 customers for the following reasons:

-   They are not concentrated. There are 1263 medical providers listed
    on GoldenPages.uz (2022), which is the largest online business
    directory in Uzbekistan. In addition, not every medical provider is
    registered with GoldenPages, driving down the concentration even
    further. Patients are even less concentrated, as virtually every
    resident of Uzbekistan will visit a doctor at some point in the
    future.

-   While monetization has not yet been discussed, in any case, each and
    every patient will only use the application individually. In
    contrast, medical providers, specifically those run by the state,
    will have considerable leverage given that individual state-owned
    clinics would not pay for the product; rather, the Ministry of
    Health, or another government body would negotiate terms or make a
    purchase for all of their clinics, if not at least a significant
    portion.

-   The product in question is differentiated. In our analysis of
    competitors within the industry, we determined that a functionally
    identical product offering was currently non- existent.

-   The product would save the buyer money. In terms of patients, time
    spent waiting in a queue is money lost in the form of wages and
    productivity. In terms of medical providers,

 more efficient use of staff time would result in lower expenditures in
 the form of salaries paid to doctors and specialists.

 We can conclude that the power of customers is low to moderate.

 **Threat of Substitutes**

 The appointment booking system has a couple of alternatives, both of
 which are practiced:

1.  Booking an appointment over the phone: As of today, this is one of
    two major options when visiting a doctor in Uzbekistan. This method
    in particular poses the biggest threat because it is currently
    standard practice in the industry. It's a fairly reliable,
    straightforward, and easy way to book an appointment, and the only
    pre-requisite is access to a mobile or landline phone on the
    patient's part. While medical providers and doctors would benefit
    from an online booking system, there is effectively nothing
    preventing them from continuing to operate over the phone.

2.  Live queue/walk-in: The other option is to forego an appointment and
    make a visit without one. While we've discussed the drawbacks and
    costs of waiting in line and potentially having to make a return
    visit, it would be illogical to assume that demand across different
    types of specialists, different providers, different cities, and
    even different doctors within the same field and provider is the
    same. We can suppose that patients who regularly visit the same
    doctor have a general idea of how busy they usually are, and in the
    case of those patients who wouldn't have to wait in a queue either
    way, the extra hassle of scheduling an appointment (online or
    otherwise) is simply not worth it.

 In this instance, the threat posed by substitutes are high.

## Monetization

 In 2021, global consumer spending on mobile applications reached
 \$170bn (Ceci, 2022a). To ensure the sustainability and long-term
 development of an application, monetization is a crucial aspect. In
 order to choose a monetization model which is appropriate for our
 application, it is important to categorize and identify the value it
 offers customers. In a study conducted by Tang (2016), mobile
 applications were categorized into two categories based on what users
 expected to get out of it: utilitarian and hedonic. A utilitarian
 perspective focuses on ease of use and

 aesthetic appeal, while a hedonic perspective includes a personal
 emotional attachment or achievement component, such as those commonly
 found in mobile games. In addition, the study further categorizes apps
 based on the type of benefits sought by the user:

1.  Convenience: Apps that simplify daily life, enhance efficiency
    and/or reduce search and decision costs.

2.  Communication: Instant messaging apps

3.  Social Networking: Apps that offer users a sense of belonging and
    acceptance among social groups

4.  Entertainment: Games, media, music, etc.

5.  Value sharing: Apps that allow users to share their values and earn
    social recognition

 Based on these categories, we can deduce that AppointMed is a
 utilitarian application offering users convenience, by simplifying a
 routine process.

 With this in mind, several key monetization models can be analyzed to
 find the optimal choice:

 **Freemium**

 "Freemium" (from the words "free" and "premium") monetization is a
 business model in which a mobile application can be downloaded for
 free, and which generates revenue solely from In App Purchases (Tang,
 2016). These purchases can vary in terms of what they offer, depending
 on the type of application. For example, a mobile game might sell
 in-game currency as an In App Purchase, whereas a fitness tracker with
 In App Advertisements may offer users the option to permanently remove
 adverts for a one-time payment.

 **Paid**

 "Paid" monetization is a business model in which revenue is generated
 solely from purchasing the application. In certain cases, a "trial"
 version may be offered to showcase the application's features, but it
 is usually the exception rather than the norm. This type of
 monetization model is the least popular both in the United States and
 globally, with 8% of apps in the United States and 3% of apps globally
 choosing to monetize in this manner (Ceci, 2022b). Note, that
 statistics on the distribution of monetization methods in Uzbekistan
 were not available.

 **In App Advertising**

 In App Advertising is a monetization method in which a mobile
 application is offered for free, and revenue is generated by
 displaying advertisements across the user interface. These
 advertisements may come in one of many, or a combination of multiple
 forms (Tasyurek, 2021):

1.  Banner ads: Small rectangular images typically placed across the top
    or bottom of the screen. Minimally intrusive and easy to implement.

2.  Interstitial ads: Fully immersive ads which occupy the whole screen.
    May or may not be restrictive in terms of when the user is allowed
    to close the ad. Typically the most intrusive form of advertisement,
    usually to the annoyance of users.

3.  Rewarded ads: Advertisements, often in video format, which
    incentivize playback by offering an in-app reward. Offers a good
    balance between intrusiveness and minimizing user frustration, since
    it is usually optional to open.

4.  Native ads: Advertisements, which are designed to fit in with the
    general aesthetic of the application. Usually employed in
    applications where there is a "feed" of content within which the
    adverts can be seamlessly integrated. Ex. Facebook, Instagram ads,
    etc.

 **Subscription**

 Subscription-based monetization is a business model in which revenue
 is generated on a continual basis through weekly/monthly/yearly
 subscription fees. Felix Krohn (2018), Vice President of Wolters
 Kluwer argues that market conditions are shifting towards a customer-
 centric environment, and that the increase in popularity of
 subscription-based models are a reflection of that shift. He also
 argues that the business objective of creating a "hit" product is
 changing towards increasing the customer lifetime value, and
 subscription-based products are ones which evolve with the customer
 over time.

 **In App Promotions**

 In App Promotions are a form of monetization whereby suppliers (in
 this case medical providers) pay to increase their exposure on the
 application. Usually, this is achieved by modifying content algorithms
 to promote certain results over others. For example, olx.uz, a local
 consumer-to- consumer shopping website gives users the options to
 display their listings at the top of search results for a duration of
 their choosing if they are willing to pay.

![image](https://user-images.githubusercontent.com/79659647/175264747-a90e8937-659d-4cf9-a14b-80655527cf13.png)

 Fig. 3.3(a). Most popular monetization strategies, in the US and
 Globally, 2021.

### Choosing the Correct Model

 When choosing the monetization model for the patient-side, it is
 important to account for the financial constrictions of the population
 discussed in the 'Background' section of the report. Thus, paid,
 subscription-based, and freemium models would not be ideal for this
 purpose.

 Instead, in-app-advertisements in the form of banner ads and native
 ads would strike the ideal balance between financial accessibility for
 consumers, and minimizing the harm advertisements bring to the user
 experience.

 The corporate-side paints a similar picture. As discussed, many public
 healthcare providers in the country run under an insufficient budget,
 which would rule out paid or subscription-based access. Therefore,
 launching with an in-app-promotion model would allow all providers to
 use and take advantage of the application, while providers that have
 the budget to promote their establishments can do so freely.

 While the aforementioned is the optimal model based on the current
 economic and market conditions, they may change over time. It is
 important to note that monetization strategies can and often do change
 in response to shifts in market conditions.

4.  # Computing Methodology

    1.  ## Justification of Hardware/Software Used

        1.  ### User Platform

 A mobile application was determined to be the ideal choice of platform
 for the project.

 It is no secret that maximizing consumer reach plays an important role
 in determining the success of a product. This means that the platform
 of choice would have to be one which is accessible by the highest
 number of people in our target audience. According to the World Bank
 Education Statistics Database, the number of personal computers per
 100 people was 3.1 in 2006 (the latest year such data was available).
 In contrast, mobile phone penetration in Uzbekistan was over 20% in
 2007, and as of 2020, it has reached a staggering 99.8% (Helgi
 Analytics, 2022).

 Based on this data, we can infer that access to a personal computer is
 significantly lower among the general population compared to a mobile
 phone.

![image](https://user-images.githubusercontent.com/79659647/175264799-f7704d9f-792c-4f12-ad8c-a6488e54f864.png)

 Fig 4.1.1(a). Mobile phone penetration in Uzbekistan, 2003 -2020.

 In addition, mobile phones have a number of benefits over a
 traditional responsive web-app, some of which were vital to the
 functionality of AppointMed:

1.  Native access to hardware such as the camera, microphone, etc.

2.  Background processing. Mobile applications have the option to run in
    the background, while web-apps are suspended as soon as the browser
    window is closed.

3.  Notifications. Web-apps currently have no way to send push
    notifications to the user, whereas mobile apps do.

### Hosting Platform

![image](https://user-images.githubusercontent.com/79659647/175264998-e89bfe54-39ac-43dd-8726-d5aff4831c29.png)

 For the server-side, we will be using a cloud computing provider, as
 it requires zero upfront cost, and in most cases, is a cheaper option
 than buying custom hardware. Cloud providers can take advantage of
 economies of scale, have built-in hardware security and redundancy,
 and offer their

 own technical support, which is why it is cheaper to rent a server
 rather than build and maintain an identical one. According to Drake
 and Turner (2022), Amazon Web Services is in the top three cloud
 computing platforms by features, and has a free 12-month trial so that
 we can test our application. Additionally, it has a wide variety of
 server tiers for vertical scaling (which may prove useful in the
 future). Furthermore, I have prior experience using AWS from the
 Distributed Systems and Cloud Computing module.

### Backend Server Programming Language/Framework

![image](https://user-images.githubusercontent.com/79659647/175265021-72dbf6ab-c135-4997-920f-b030da86de15.png)
 
 For the backend server, the .NET 6
 framework (which is coded in C#) was chosen for development. First,
 .NET is an extremely performant framework. ASP.NET is ranked number 1
 on the TechEmpower 2021 Plaintext Response Benchmark, beating out
 other popular alternatives such as Node.js and Django.

 In addition, C# has a large support community on StackOverflow, with
 over 1.5 million questions asked. Having the option to refer to an
 experienced community of developers can greatly assist the development
 process. Furthermore, the framework is guaranteed long-term support
 from Microsoft. .NET and C# both receive major yearly updates, and
 .NET 6 is promised to receive 3 years of long-term support. Moreover,
 .NET is fully cross-platform, giving developers the option to host on
 Windows, Linux, and MacOS. Lastly, and most importantly, I have a
 substantial amount of experience developing applications with C# and
 .NET, both from

 previous course works and personal projects.

 **Authentication and Authorization Management**

 For authentication and authorization, it was decided to use the
 ASP.NET Identity extension, which is developed by Microsoft. ASP.NET
 Identity seamlessly integrates into .NET applications, and has an
 extremely wide variety of customization options, including but not
 limited to Claims based authentication, Role based authentication, and
 Social Login Providers such as Google, Meta, etc. It must be noted
 that using ASP.NET Identity requires additional time and effort to set
 up and manage, increasing the complexity of the application. There are
 several reasons it was used, as opposed to a simpler and easier to
 manage solution such as Firebase:

1.  Allows us to manage the hosting and persistence of user data, rather
    than being locked in to Google's proprietary platform.

2.  Offers better fine tuning of options for authentication and
    authorization.

3.  Can be integrated into the application as a separate set of
    endpoints.

4.  Is a free extension, as opposed to Firebase, which starts charging
    as the number of requests scales up.

    1.  ### Database Server

![image](https://user-images.githubusercontent.com/79659647/175265124-11d5d05a-8943-43ef-9862-d17d43efe541.png)

 For the database server, MS SQL was
 determined to be the optimal choice. For starters, MS SQL is a
 relational database, which is the type typically used to store
 structured data such as ours. In addition, SQL servers ensure more
 reliability and data integrity compared to NoSQL counterparts
 (Sahatqija et. al., 2018). Moreover, relational
 databases have very secure mechanisms which ensure the security of the
 services (Mohamed et. al., 2018). Furthermore, prior experience using
 MS SQL for course works also played a key role in choosing this
 specific database management system. However, relational databases do
 have some disadvantages over their non-relational counterparts which
 must be addressed. Relational databases are not dynamic in their
 schema, meaning that as the structure of the data changes, it is more
 difficult to manage compared to non-relational databases. In addition,
 SQL requires a schema upfront, which forces developers to map out the
 data structure before starting to code. In our project, both of these
 issues have been solved using Entity Framework Core, an object
 relational mapping framework which utilizes a code-first approach to
 development. With EF
 Core, entities and their relationships can be defined in code,
 relieving developers of the hassle of defining a schema. Furthermore,
 any changes in the data structure can be reflected in the database
 using the built-in migration functionality.

### Frontend Mobile Application Programming Language/Framework

![image](https://user-images.githubusercontent.com/79659647/175265186-61681936-71d3-45dc-bcc1-db22c23dbc4e.png)

 For the mobile application development,
 the Flutter Framework, using the Dart programming language, was
 chosen. As previously discussed, maximizing consumer reach was a
 priority for this project, so it was necessary to choose a cross-
 platform development framework which could deploy to both Android and
 iOS with a single codebase. Flutter is one of just a

 handful of cross-platform development frameworks, which also include
 React Native, Xamarin, and Ionic. In terms of performance, Flutter is
 the closest to native applications, due to the fact that it compiles
 directly to native code, as opposed to React Native, for example,
 which uses a JavaScript engine as a bridge. Flutter and Dart are both
 supported by Google, who has continued to rapidly develop and update
 both the language and framework since their inception. Lastly, one of
 the personal objectives set for this project was to learn a new
 programming language and framework. As the popularity of Flutter and
 Dart continue to rise rapidly, and with the addition of support for
 both web and cross-platform desktop application development, it was a
 clear choice.

## Software Architecture

#### Deployment

 For the server-side application, a monolithic architecture was chosen
 for deployment. Monolithic applications have a number of benefits and
 drawbacks (Kharenko, 2015), outlined below:

 Benefits:

-   Faster initial development and testing phase

-   Easier to package and deploy

-   Scales both horizontally and vertically

-   Does not require the development of a communication mechanism to
    send data between services

-   Easier to implement systemwide changes Drawbacks:

-   Fundamentally limited in size and complexity

-   Larger complexity leads to difficulty understanding and maintaining
    code

-   Harder to develop and maintain in a team environment as opposed to
    microservices

-   Partial failure brings down the entire system

-   Difficult to implement new technologies and frameworks down the line

 The limited scale of the application, the tight schedule, and the
 restriction to a single developer meant that a monolithic application
 was the optimal choice, despite its drawbacks.

#### Code Architecture

 For the logical architecture of the code, clean architecture was
 chosen for its numerous benefits. First, structuring the application
 around the domain and its core entities allows developers to change
 frameworks and dependencies with minimal work to transition. Next,
 decoupling different sections of the application means that changes
 are easier to implement without breaking the entirety of the codebase.
 Furthermore, this approach is highly maintainable regardless of the
 scale of the application.

![image](https://user-images.githubusercontent.com/79659647/175265274-9941b05a-3397-4eb1-a9cf-f7fb3e5e9b4e.png)

 Fig. 4.2(a). Typical Clean Architecture model

 In our server-side application, we can see this pattern in the
 dependency graph:

![image](https://user-images.githubusercontent.com/79659647/175265320-e67575b2-d02c-4756-b404-df53f4fd17e0.png)

 Fig. 4.2(b). Dependency graph of the server-side application project.

## Data Structure

#### Application Core

![image](https://user-images.githubusercontent.com/79659647/175265374-c6641fee-6492-420d-89e4-3e5eb4526cfc.png)

 Fig. 4.3(a). Table diagram of the database schema, domain layer only.

#### Identity Management

![image](https://user-images.githubusercontent.com/79659647/175265444-672936dd-b4a1-4b3c-892e-3f2770edc291.png)

 Fig. 4.3(b). Table diagram of the database schema, identity models
 only.

## Activity Flow

![image](https://user-images.githubusercontent.com/79659647/175265481-793fa26d-5112-46f9-ab8e-353e052c66e7.png)

 Fig. 4.4(a). Activity flow for the client-side mobile application.

## Development Lifecycle

 For the software development lifecycle, an agile methodology,
 specifically Kanban was chosen to manage the workflow of the project.
 Initially, the plan was to implement the Scrum methodology, but
 several drawbacks of the approach were identified during the process.
 First, while Scrum has found success in many team environments, its
 efficiency within a project with only one developer is questionable.
 Assigning the roles of product owner, scrum master, and team member is
 rather pointless when there is only one person to assign it to. In
 addition, the scrum methodology calls for daily scrum meetings. While
 this is a great way for members to communicate their progress and any
 issues they may be facing, and for the scrum master to

 ensure that the process is going smoothly, it is unnecessary when both
 parties consist of the same person. Furthermore, scrum requires
 segmenting the workflow into 'sprints' with a fixed length of time,
 and assigning 'stories' to each member. This, in turn, requires
 splitting larger, more abstract tasks into smaller tasks, and
 assigning 'points' based on the difficulty of the task. Again, while
 this is an effective way to track progress, it can consume substantial
 amounts of time which could otherwise be spent on actual development
 rather than planning.

 In contrast, Kanban proved to be a better fit, because of its less
 restrictive guidelines and emphasis on keeping the workflow tracking
 simple:

![image](https://user-images.githubusercontent.com/79659647/175265529-779f2c93-f524-48d3-9c44-389ed803661c.png)

 Fig. 4.5(a). Typical Kanban board used to monitor workflow.

 What's more, it was a better fit for the project due to the way
 planning was set up in the initial phases, with larger, more abstract
 tasks, and varying durations assigned to each task.

## Tasks

#### Data Structure Modelling. 11/10/21 -- 11/30/21

 This task consisted of planning out the core domain of the project and
 deciding on how the objects would be structured and interact with each
 other. Please refer to Figures 4.3(a) and 4.3(b) for the completed
 version of the schema. Note, that these are the final versions of the
 schema; the model changed over the course of the project, and the
 database went through multiple migrations.

#### System Architecture Modelling. 12/3/21 -- 12/29/21

![image](https://user-images.githubusercontent.com/79659647/175265561-5d0aeb24-af79-448e-9a39-98236a271d60.png)

 To stay consistent with clean architecture guidelines, the application
 was split into three separate projects: Core, containing all of the
 models, dtos, and interfaces; Infrastructure, containing the data
 access layer, both for the appointment system and authentication; API,
 containing the exposed endpoints for our client-side mobile
 application to communicate with the server-side application.

 In addition, dependencies were compliant with clean architecture
 guidelines as well. Referring to Figure 4.2(b), we can observe that
 dependencies flow only inwards towards the application core layer.
 This approach ensures that our core domain is not dependent on any
 external frameworks, packages, etc., and that any changes in the
 implementation (such as the data access, endpoints, mapping, etc.)
 will not affect the domain layer.

#### Backend logic and API Development. 1/5/22 -- 2/12/22

 As previously mentioned, Entity Framework Core was used to map our
 objects and create the database scheme. Entity Framework Core also
 allows us to utilize its built-in methods to access and modify our
 database tables. Our data access/service classes were initialized in
 the API using dependency injection. The ASP.NET web API handles all of
 the middleware and routing.
 ASP.NET Identity is used to handle authentication and authorization.
 Most controllers are locked
 using Role based authorization. All controllers are locked using the
 provided authentication scheme. The following endpoints are exposed to
 the user:

![image](https://user-images.githubusercontent.com/79659647/175265888-79bb5759-4fd7-459b-b612-90d68c13926d.png)
![image](https://user-images.githubusercontent.com/79659647/175265905-c4200bed-38a9-4e72-9dd5-f3a3206ad044.png)
![image](https://user-images.githubusercontent.com/79659647/175265935-59eb50b3-3228-45c4-9122-b98cff8dff0a.png)
![image](https://user-images.githubusercontent.com/79659647/175265957-225b3c71-24f3-4909-abd9-5d0bc9524877.png)
![image](https://user-images.githubusercontent.com/79659647/175265976-9abdc9b5-d140-469a-b371-c2239bd0c31d.png)


#### Backend Quality Assurance. 2/13/22 -- 2/17/22

 All endpoints are tested, both for functionality, and for
 authentication/authorization. More extensive testing details can be
 found in the results section.

#### UX Prototype. 2/18/22 -- 2/19/22 Splash Screen and Onboarding

 ![image](https://user-images.githubusercontent.com/79659647/175266519-c6512f01-dd81-4ce8-ae6c-42aa1c9b47c1.png)

 ![image](https://user-images.githubusercontent.com/79659647/175266596-57eb46d2-61e8-4679-89c3-dba15309b562.png)

#### Registration Forms

![image](https://user-images.githubusercontent.com/79659647/175266719-8d519aef-f363-4571-8455-eae1198a7cb9.png)

#### Main Screens

![image](https://user-images.githubusercontent.com/79659647/175266811-c4209fa0-e370-4d98-9f5a-6ef9df5cc25b.png)

#### Admin Panel Prototypes (Backlogged)

![image](https://user-images.githubusercontent.com/79659647/175267053-986bba27-0ab6-403f-b871-cecbabbdd61b.png)
![image](https://user-images.githubusercontent.com/79659647/175267181-cdedbaee-c3fe-4abf-a9d0-839a9b51e86c.png)


#### Mobile UI Development. 2/20/22 -- 3/7/22

 Due to various delays, the client-side mobile application was
 developed under a very limited time frame. As a result, research into
 various architecture models and their implementation could not be
 accomplished. Nevertheless, the code *is* structured, albeit not to
 the greatest extent.

 Widgets have been refactored to meet certain standards and best
 practices. Duplication of code is present to a limited extent, but
 time constraints did not allow for refactoring.

#### Mobile Application prototype. 3/10/22 -- 3/12/22

 A prototype with a fully working feature set was developed, but
 certain bugs still needed to be corrected.

#### Mobile UI Quality Assurance. 3/13/22 -- 3/15/22

 All features were tested, bugs were corrected for the most part. More
 extensive testing details can be found in the results section.

# Results

 All in all, we managed to meet all of the objectives we set at the
 beginning of the project:

#### Business Objectives:

-   Develop a financially sustainable and viable appointment booking
    framework which can be integrated into the current systems of
    medical providers with ease

-   Analyze different monetization options and select one that results
    in the lowest costs for both patients and medical providers alike

-   Analyze the different platforms available for development (mobile,
    web, etc.), and select one that results in the largest reach to
    customers

-   Define the target user demographic

#### Academic Objectives

-   Analyze the general state of the current healthcare system of
    Uzbekistan

-   Outline the shortcomings, inefficiencies, and issues facing the
    healthcare system

-   Identify the root causes of said issues

-   Develop a potential solution supported by the research that has been
    conducted

-   Analyze the results of the solution and come to a conclusion on its
    potential viability in a real-world environment

#### Personal Objectives

-   Develop an application that can be used within a portfolio to
    showcase my experience and skills with modern OOP languages

-   Follow industry standard 'best practices' during the development
    phase

-   Learn how to plan a project and manage time effectively

-   Learn a new programming language and mobile application development
    framework, in the form of Flutter and Dart

-   Challenge myself to create an application of a size and scale on
    which I have not worked on before

 As for the technical objectives and plan we laid out, all of our tasks
 were completed by the deadline. While certain changes had to be made,
 both to the scope of the project and the Gantt chart, these changes
 were planned and implemented to be able to deliver a working product
 by the end of the timeline.

|           TASK NAME                        |           START DATE    |           END DATE    |           START ON DAY*    |     DURATION*     (WORK DAYS)    |           PERCENT COMPLETE    |
|--------------------------------------------|-------------------------|-----------------------|----------------------------|----------------------------------|-------------------------------|
|     Business Idea                          |     10/1                |     10/15             |     0                      |     15                           |     100%                      |
|     Background Research                    |     10/15               |     10/21             |     14                     |     7                            |     100%                      |
|     Project Scope   and Limitations        |     10/26               |     10/31             |     25                     |     6                            |     100%                      |
|     Timeline Planning                      |     11/1                |     11/2              |     31                     |     2                            |     100%                      |
|     Project Initiation Document            |     11/3                |     11/9              |     33                     |     7                            |     100%                      |
|     Data Structure Modelling               |     11/10               |     11/30             |     40                     |     21                           |     100%                      |
|     System Architecture Modelling          |     12/3                |     12/29             |     63                     |     27                           |     100%                      |
|     Backend logic   and API Development    |     1/5                 |     2/12              |     96                     |     39                           |     100%                      |
|     Backend   Quality Assurance            |     2/13                |     2/17              |     135                    |     5                            |     100%                      |
|     UX Prototype                           |     2/18                |     2/19              |     140                    |     1                            |     100%                      |
|     Mobile UI Development                  |     2/20                |     3/7               |     141                    |     17                           |     100%                      |
|     Mobile Application prototype           |     3/10                |     3/12              |     160                    |     3                            |     100%                      |
|     Mobile UI Quality Assurance            |     3/13                |     3/15              |     163                    |     3                            |     100%                      |
|     Deploying a Working Prototype          |     3/23                |     3/28              |     173                    |     6                            |     100%                      |
|     Deploying Production Version           |     4/1                 |     4/2               |     182                    |     2                            |     100%                      |
|     Analyzing Outcomes and Conclusion      |     4/3                 |     4/8               |     184                    |     6                            |     100%                      |
|     Finalizing Report                      |     4/9                 |     4/13              |     190                    |     5                            |     100%                      |

## Testing

 Black-box testing was conducted to ensure the functionality of both
 the server and client-side applications:

|     Test Case                                                                 |     Expected Result                                                             |     Actual Result    |
|-------------------------------------------------------------------------------|---------------------------------------------------------------------------------|----------------------|
|     Try to access   app without an internet connection                        |     App displays an error screen asking to try again with   internet access.    |     As expected.     |
|     Register a new patient/doctor.                                            |     Successfully register a new patient/doctor.                                 |     As expected.     |
|     Register a new   patient/doctor     with invalid email   and password.    |     Error message is returned.                                                  |     As expected.     |
|     Login using correct credentials.                                          |     Successful login.                                                           |     As expected.     |
|     Login using   incorrect credentials.                                      |     Error message is returned.                                                  |     As expected.     |
|     Update user   profile.                                                    |     Successfully updated user profile.                                          |     As expected.     |
|     Schedule Appointment.                                                     |     Successfully scheduled appointment.                                         |     As expected.     |
|     View List   of Appointments.                                              |     List of Appointments is presented.                                          |     As expected.     |
|     Check into Appointment.                                                   |     Patient checks   in and appointment status   is     updated.                |     As expected.     |
|     Complete Appointment.                                                     |     Doctor completes   appointment and status   is updated.                     |     As expected.     |
|     Cancel Appointment.                                                       |     Patient cancels appointment and status is updated.                          |     As expected.     |

# Conclusion

 The appointment booking solution, AppointMed, provides users with an
 easy and intuitive way to book appointments with the doctor. Over the
 course of the project, the business, academic, and personal objectives
 that were laid out have been met. In response to certain delays, the
 scope and feature set of the application was scaled back. This planned
 change allowed for the delivery of a functioning system by the
 deadline. It is worth pointing out that the feature set and overall
 purpose of the application is founded based on the market analysis
 conducted earlier in the process. The application is designed to
 fulfill a demand within the market that has not yet been fulfilled.
 With these factors in mind, it can be concluded that with further
 developments and improvements, the solution has potential long-term
 viability.

7.  # Final Chapter

    1.  ## Self-Assessment

#### Planning

 All in all, while I did reach the objectives that I had set, I was not
 entirely content with the manner in which it was reached. The initial
 scope and planning of the project exposed my lack of experience and
 knowledge in accurately assessing the amount of work it would take to
 complete such a project, and the amount of work I could do in that
 given timeframe. As a result, certain features, such as the admin
 panel for clinic administrators, had to be backlogged for future
 development. In addition, the initial planning phase of the project
 was flawed. By segmenting the project into large, abstract chunks, it
 was difficult to estimate how much of the project was completed. That
 led to large spans of time where the project was not being worked on,
 because I was under the impression that progress was going according
 to schedule. This approach backfired when I realized that the amount
 of time allocated towards creating the frontend mobile application
 would not be enough without "crunch" time. This led to certain corners
 to be cut, most prominently in UX design and testing. Moreover, in the
 first version of my Gantt time table, I failed to account for the time
 it would take to submit course works from the other modules. While I
 did partially correct it when submitting the progress report, I now
 realize that the amount of time I dedicated towards course works and
 exam preparation was not sufficient, leading to even more schedule
 revisions down the line.

#### Coding

 On the technical side of things, there were no major difficulties,
 only mistakes stemming from a lack of experience working on a project
 of this size. Looking back, I now realize that I had spent an
 excessive amount of time planning and deciding on a system
 architecture which would be easy to maintain. After deciding to
 develop the application using the Clean Architecture model, I quickly
 found out that on a project of this scale, complex architectures such
 as the one I chose would end up unnecessarily fragmenting the codebase
 and requiring more time to maintain than a more traditional and simple
 approach. I also now realize that learning an entirely new language
 and framework from scratch (while potentially beneficial for my
 career) was something best done during my own time, and not as a
 prerequisite to completing my final year project. Initially, I had
 planned on developing the server-side application with Django (a
 framework with which I had no experience), but luckily, decided to
 switch back to .NET very early in the process. If I had to undertake a
 similar assignment in the future, I would make sure to stick to an
 area of development I am more familiar with.

#### Character

 Finally, this project was somewhat of a rude awakening that I needed
 to learn to manage my time effectively. There were many instances over
 the course of this past year where I knew I needed to be working on
 the project, but chose to prioritize less urgent tasks. All of the
 work that was behind schedule did eventually catch up to me in the
 latter stages of the process, and I had no choice but to put
 everything else on hold and make up for lost time. Reflecting on this
 journey, I can see that it was a clear example of why certain people,
 teams, and companies are able to meet deadlines and achieve the
 targets they set with ease, and why others reap the consequences of
 the decisions they have sowed, and are left paying back the
 metaphorical 'debt' they have taken on. I've also seen how small
 choices, whether it be in the planning, designing, or development
 phase, can drastically alter the direction of a project, and why it's
 important to not only monitor the progress of a project, but also make
 sure that the initial goals, visions, and targets are still aligned
 with what is being produced.

## Limitations

 First and foremost, I'd like to point out that this project was
 heavily constrained in terms of time, manpower, and experience. While
 the background research and methodology were completed to the best of
 my abilities, I am not someone who has experience working in, or
 extensively studying the healthcare sector, nor am I someone who fully
 understands the economic or social factors in play. Moreover, the
 limited literature that *is* available on the subject is often
 outdated, poorly structured, or contains potentially subjective points
 which are not backed by concrete, quantitative data. Objective,
 reliable, and relatively recent studies such as the report by the WHO
 (Ahmedov et. al., 2014) are few and far between.

 Moreover, both the server-side and client-side are limited in
 features. While the basic functionality is present, developing and
 deploying an application for real world use would require a more
 robust feature set, such as a chat system, clinic and doctor review
 system, test result delivery system, etc. In addition, while the
 server-side application is built on a performant framework, it has not
 been tested under extensive loads, such as those which it would
 experience with a high number of users.

## Future Improvements

 Circling back to the scope definition of the project, we mentioned a
 few key features which could be added in the future:

-   Messaging feature between doctors and patients

-   Test result collection

-   Review system for medical providers and doctors

-   Payment system

-   Admin Panel

 In addition, I believe restructuring the application in a way which
 makes it easy to integrate within a current EMR would benefit its
 long-term viability. While most medical providers in the country still
 operate on paper records, the government has expressed interest in
 switching to a unified electronic record system, meaning that a large
 portion of the country's medical providers would be operating with an
 EMR at some point in the future. Adopting an appointment system

 which seamlessly integrates into their current system would be a more
 enticing option than having to use two separate applications.

 Lastly, the project would benefit from a product viability assessment,
 ideally conducted by someone with experience in the Uzbek market and
 in the healthcare sector. While the design choices and methodology
 were justified based on research (where possible), in a developing
 country such as Uzbekistan, market conditions, social factors, etc.
 are constantly shifting, and having someone with the knowledge and
 expertise of designing a product for the local market would be
 advantageous.

# Reference List

-   Moir, M and Barua, B (2021). The Private Cost of Public Queues for
    Medically Necessary Care, 2021. Frasier Research Bulletin. Available
    from
    [[https://www.fraserinstitute.org/sites/default/files/private-cost-of-public-queues-2021.pdf]{.underline}](https://www.fraserinstitute.org/sites/default/files/private-cost-of-public-queues-2021.pdf)
    \[Accessed 5 November 2021\].

-   100 Ideas for Uzbekistan (no date). List of Winners. Available from
    [[https://100ideas.uz/en/goals]{.underline}](https://100ideas.uz/en/goals)
    \[Accessed 5 March 2022\].

-   Ahmedov, M. et al. (2014). Uzbekistan: health system review. World
    Health Organization.

-   Asadov, D. A., & Aripov, T. Y. (2009). The quality of care in
    post-soviet Uzbekistan: are health reforms and international efforts
    succeeding? Public Health, 123(11), 725--728.

-   Bogodvid, M. (2020). An electronic queue for an appointment with a
    doctor appeared in Uzbekistan. *Sputnik News.* Available from
    [[https://uz.sputniknews.ru/20201021/V-]{.underline}](https://uz.sputniknews.ru/20201021/V-Uzbekistane-poyavilas-elektronnaya-ochered-dlya-zapisi-k-vrachu-15224018.html)
    [[Uzbekistane-poyavilas-elektronnaya-ochered-dlya-zapisi-k-vrachu-15224018.html]{.underline}](https://uz.sputniknews.ru/20201021/V-Uzbekistane-poyavilas-elektronnaya-ochered-dlya-zapisi-k-vrachu-15224018.html)
    \[Accessed 5 March 2022\].

-   Ceci, L. (2022a). Most popular app monetization methods by
    publishers from the United States as of March 2022. *Statista.*
    Available from
    [[https://www.statista.com/statistics/1119916/app-monetization-methods-united-states-app-]{.underline}](https://www.statista.com/statistics/1119916/app-monetization-methods-united-states-app-publishers/)
    [[publishers/]{.underline}](https://www.statista.com/statistics/1119916/app-monetization-methods-united-states-app-publishers/)
    \[Accessed 18 March 2022\].

-   Ceci, L. (2022b). Worldwide consumer spending on mobile apps from
    2016 to 2021. *Statista.* Available from
    [[https://www.statista.com/statistics/870642/global-mobile-app-spend-]{.underline}](https://www.statista.com/statistics/870642/global-mobile-app-spend-consumer/)
    [[consumer/]{.underline}](https://www.statista.com/statistics/870642/global-mobile-app-spend-consumer/)
    \[Accessed 18 March 2022\].

-   Curtis, K. R., & Allen, S. (2018). Target Market Identification and
    Data Collection Methods.

-   Decree of the President of the Republic of Uzbekistan, dated
    02.08.2018 No. PP-3894. On Measures To Introduce An Innovative Model
    Of Healthcare Management In The Republic Of Uzbekistan.

-   Drake, N. and Turner, B. (2022). Best cloud computing services
    in 2022. *ITProPortal*. Available from
    [[https://www.itproportal.com/guides/best-cloud-computing-services/]{.underline}](https://www.itproportal.com/guides/best-cloud-computing-services/)
    \[Accessed 30 January 2022\].

-   Footman K et al. (2013). Public satisfaction as a measure of health
    system performance: a study of nine countries in the former Soviet
    Union. Health Policy, 112(1):62--69.

-   GoldenPages.uz (no date). List of medical providers in Uzbekistan.
    Available from \[Accessed 12 March 2022\].
    [[https://www.goldenpages.uz/rubrics/?Id=1372]{.underline}](https://www.goldenpages.uz/rubrics/?Id=1372)

-   Heigl Analytics (2022). Mobile Phone Penetration (As % of
    Population) in Uzbekistan. *Heigl Library.* Available from
    [[https://www.helgilibrary.com/indicators/mobile-phone-penetration-]{.underline}](https://www.helgilibrary.com/indicators/mobile-phone-penetration-as-of-population/uzbekistan/)
    [[as-of-population/uzbekistan/]{.underline}](https://www.helgilibrary.com/indicators/mobile-phone-penetration-as-of-population/uzbekistan/)
    \[Accessed 14 March 2022\].

-   Horev Medical (no date). Online Appointment Scheduling. Available
    from
    [[https://horevmedical.uz/zapis.html]{.underline}](https://horevmedical.uz/zapis.html)
    \[Accessed 27 February 2022\].

-   Kharenko, A. (2015). Monolithic vs. Microservices Architecture.
    Available from
    [[https://articles.microservices.com/monolithic-vs-microservices-architecture-5c4848858f59]{.underline}](https://articles.microservices.com/monolithic-vs-microservices-architecture-5c4848858f59)
    \[Accessed 24 March 2022\].

-   Krohn, F. (2018). Subscription Monetization. *LinkedIn.* Available
    from
    [[https://www.linkedin.com/pulse/subscription-monetization-felix-krohn]{.underline}](https://www.linkedin.com/pulse/subscription-monetization-felix-krohn)
    \[Accessed 21 March 2022\].

-   Law of the Republic of Uzbekistan No. RK-666. Article 27-1

-   Mannopov, K. (2022). BIS Project Progress Report.

-   M. A. Mohamed, O. G. Altrafi, and M. O. Ismail. "Relational vs.
    NoSQL databases: A survey" in International Journal of Computer and
    Information Technology, vol. 03, no. 03, pp. 598--601, May 2014.

-   McDonald, C. J., & Tierney, W. M. (1988). Computer-stored medical
    records: their future role in medical practice. Jama, 259(23),
    3433-3440.

-   Michas, F. (2021). Number of doctor visits per capita in selected
    countries, 2019. *Statista.* Available from
    [[https://www.statista.com/statistics/236589/number-of-doctor-visits-per-capita-]{.underline}](https://www.statista.com/statistics/236589/number-of-doctor-visits-per-capita-by-country/)
    [[by-country/]{.underline}](https://www.statista.com/statistics/236589/number-of-doctor-visits-per-capita-by-country/)
    \[Accessed 27 February 2022\].

-   O' Dea, S. (2021). Share of adults in the United States who owned a
    smartphone from 2015 to 2021, by age group. *Statista.* Available
    from
    [[https://www.statista.com/statistics/489255/percentage-of-us-smartphone-owners-by-age-]{.underline}](https://www.statista.com/statistics/489255/percentage-of-us-smartphone-owners-by-age-group/)
    [[group/]{.underline}](https://www.statista.com/statistics/489255/percentage-of-us-smartphone-owners-by-age-group/)
    \[Accessed 5 March 2022\].

-   Porter, M. (1979). How Competitive Forces Shape Strategy. *Harvard
    Business Review.* Available from
    [[https://hbr.org/1979/03/how-competitive-forces-shape-strategy]{.underline}](https://hbr.org/1979/03/how-competitive-forces-shape-strategy)
    \[Accessed 12 March 2022\].

-   RB Asia, 2019. Uzbekistan Healthcare Report. Market Overview,
    Trends, Reforms and Forecasts. Available from
    [[https://en.rbasia.uz/zdravohranenie-sektor-uzbekistan]{.underline}](https://en.rbasia.uz/zdravohranenie-sektor-uzbekistan)
    \[Accessed 3 November 2021\].

-   Robinson, S. (2021). Health Systems in Action: Uzbekistan. *European
    Observatory on Health Systems and Policies, WHO Europe.*

-   Sahatqija, K. et al. (2018). Comparison between relational and NOSQL
    databases. 41st international convention on information and
    communication technology, electronics and microelectronics (MIPRO)
    (pp. 0216-0221). IEEE.

-   Tang, A. K. (2016). Mobile app monetization: app business models in
    the digital era. International Journal of Innovation, Management and
    Technology, 7(5), 224.

-   Tasyurek, D. (2021). Types of Mobile Ads: What Are They? Why Are
    They Important? *Storyly.* Available from
    [[https://storyly.io/types-of-mobile-ads-and-their-importance/]{.underline}](https://storyly.io/types-of-mobile-ads-and-their-importance/)
    \[Accessed 18 March 2022\].

-   TechEmpower (2022). Web Framework Benchmarks, Round 20. Available
    from
    [[https://www.techempower.com/benchmarks/#section=data-r20&hw=ph&test=plaintext&a=2]{.underline}](https://www.techempower.com/benchmarks/#section%3Ddata-r20%26hw%3Dph%26test%3Dplaintext%26a%3D2)
    \[Accessed 24 March 2022\].

-   Wang, S. J. et al. (2003). A cost-benefit analysis of electronic
    medical records in primary care. The American journal of medicine,
    114(5), 397-403.

-   World Bank (2006). Number of Personal Computers per 100 People in
    Uzbekistan. *World Bank DataBank -- Education Statistics.* Available
    from

> [[https://databank.worldbank.org/reports.aspx?source=education-statistics-\~-all-]{.underline}](https://databank.worldbank.org/reports.aspx?source=education-statistics-~-all-indicators&selectedDimension_Stat_Ctry_Ext)
> [[indicators#selectedDimension_Stat_Ctry_Ext]{.underline}](https://databank.worldbank.org/reports.aspx?source=education-statistics-~-all-indicators&selectedDimension_Stat_Ctry_Ext)
> \[Accessed 14 March 2022\].

-   World Bank (2020). GDP per Capita. Available from
    [[https://data.worldbank.org/indicator/NY.GDP.PCAP.PP.CD]{.underline}](https://data.worldbank.org/indicator/NY.GDP.PCAP.PP.CD)
    \[Accessed 22 February 2022\].

-   World Bank (2020). Gini Index (World Bank estimate). Available from
    [[https://data.worldbank.org/indicator/SI.POV.GINI?view=map]{.underline}](https://data.worldbank.org/indicator/SI.POV.GINI?view=map)
    \[Accessed 22 February 2022\].
