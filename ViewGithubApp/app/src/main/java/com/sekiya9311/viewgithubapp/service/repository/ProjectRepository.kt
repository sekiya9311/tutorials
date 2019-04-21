package com.sekiya9311.viewgithubapp.service.repository

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.google.gson.FieldNamingPolicy
import com.google.gson.GsonBuilder
import com.sekiya9311.viewgithubapp.service.model.Project
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class ProjectRepository private  constructor() {
    private val githubService: GitHubService
    init {
        val gson = GsonBuilder()
            .setFieldNamingPolicy(FieldNamingPolicy.LOWER_CASE_WITH_UNDERSCORES)
            .create()
        val retrofit = Retrofit.Builder()
            .baseUrl(GitHubService.HTTPS_API_GITHUB_URL)
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()

        githubService = retrofit.create(GitHubService::class.java)
    }

    fun getReposById(userId: String): LiveData<List<Project>> {
        return MutableLiveData<List<Project>>().also {
            githubService.getRepos(userId).enqueue(object: Callback<List<Project>> {
                override fun onFailure(call: Call<List<Project>>, t: Throwable) {
                    it.postValue(listOf())
                }

                override fun onResponse(call: Call<List<Project>>, response: Response<List<Project>>) {
                    it.postValue(response.body())
                }
            })
        }
    }

    fun getRepo(userId: String, repoName: String): LiveData<Project> {
        return MutableLiveData<Project>().also {
            githubService.getProject(userId, repoName).enqueue(object : Callback<Project> {
                override fun onFailure(call: Call<Project>, t: Throwable) {
                    it.postValue(null)
                }

                override fun onResponse(call: Call<Project>, response: Response<Project>) {
                    it.postValue(response.body())
                }
            })
        }
    }

    companion object {
        val instance: ProjectRepository
            get() = ProjectRepository()
    }
}
